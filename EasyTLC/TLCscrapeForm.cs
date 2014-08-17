using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyTLC
{
    public partial class TLCscrapeForm : Form
    {
        private List<string> rawShifts;
        private string rawMonth;
        private string rawYear;
        private iCalendar icsResult;

        public TLCscrapeForm()
        {
            InitializeComponent();
            rawShifts = new List<string>();
            icsResult = new iCalendar();

            try
            {
                using (StreamReader creds = new StreamReader(Application.StartupPath + "\\creds.ini"))
                {
                    BBYuserName.Text = creds.ReadLine();
                    BBYpassWord.Text = creds.ReadLine();
                    eventNameTextBox.Text = creds.ReadLine();

                    tlcTimeShift.Value = Int16.Parse(creds.ReadLine());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Warning: creds.ini wasn't found." + ex.Message);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            tlcBrowser.Document.All["login"].SetAttribute("value", BBYuserName.Text);
            tlcBrowser.Document.All["password"].SetAttribute("value", BBYpassWord.Text);

       // Find and click the login link
            foreach (HtmlElement curElement in tlcBrowser.Document.GetElementsByTagName("button"))
            {
                if (curElement.GetAttribute("classname").Equals("inforFormButton default"))
                    curElement.InvokeMember("click");
            }
        }

        // Scape the schedule.  Nasty screen-scraping, but oh well.
        private void scrapeButton_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement curElement in tlcBrowser.Document.GetElementsByTagName("span"))
            {
                if (curElement.GetAttribute("classname").Equals("pageTitle"))
                {
                    string rawMonthYear = curElement.InnerText;
                    rawYear = rawMonthYear.Substring(rawMonthYear.Length - 4);
                    rawMonth = rawMonthYear.Substring(0, rawMonthYear.Length - 5);
                }
            }

            foreach (HtmlElement curElement in tlcBrowser.Document.GetElementsByTagName("td"))
            {
                if (curElement.GetAttribute("classname").Equals("calendarCellRegularCurrent") || curElement.GetAttribute("classname").Equals("calendarCellRegularFuture"))
                {
                    if (curElement.InnerText.Contains("OFF"))
                        continue;

                    rawShifts.Add(curElement.InnerText.Substring(0, 24).Replace(Environment.NewLine, ""));
                }
            }

            scheduleReadout.Text += rawMonth + " " + rawYear + "\n";
            foreach (string entry in rawShifts)
                scheduleReadout.Text += entry + "\n";

            exportButton.Enabled = true;
        }

        // Create and save our .ics file.
        private void exportButton_Click(object sender, EventArgs e)
        {
            UniqueComponentList<Event> events = new UniqueComponentList<Event>(icsResult);

            for (int i = 0; i < rawShifts.Count; i++)
            {
                rawShifts[i] = rawShifts[i].Insert(19, ":00");
                rawShifts[i] = rawShifts[i].Insert(8, ":00");
            }

            string shiftPrefix = rawYear + " " + rawMonth;

            foreach (string shift in rawShifts)
            {
                string dayNumber = shift.Substring(0, 2);
                string workingShift = shift.Substring(3);

                Console.WriteLine(shiftPrefix + " " + dayNumber + " " + workingShift.Substring(0, 11));

                DateTime shiftStart = DateTime.Parse(shiftPrefix + " " + dayNumber + " " + workingShift.Substring(0, 11));
                DateTime shiftEnd = DateTime.Parse(shiftPrefix + " " + dayNumber + " " + workingShift.Substring(14));

                // To fix shifts that cross midnight.
                if (DateTime.Compare(shiftStart, shiftEnd) > 0)
                    shiftEnd = shiftEnd.AddDays(1);

                shiftStart = shiftStart.AddHours((int)tlcTimeShift.Value);
                shiftEnd = shiftEnd.AddHours((int)tlcTimeShift.Value);

                Event evt = new Event();
                evt.Summary = eventNameTextBox.Text;
                evt.Start = new iCalDateTime(shiftStart);
                evt.End = new iCalDateTime(shiftEnd);

                events.Add(evt);
            }

            iCalendarSerializer serializer = new iCalendarSerializer(icsResult);
            serializer.Serialize(icsResult, rawMonth.ToString() + ".ics");
            Application.Exit();
        }
    }
}
