﻿using DDay.iCal;
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

            // This will read in the event name, the username, the password, and the hour offset
            // from a text file called "creds.ini" in the same directory as the exe.  It will
            // silently fail if that file isn't present, and the fields will be left blank.
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
                // Silenty carry on, since this is kind of a secret feature.
            }
        }

        // Turn self off, then place the user/pass and click login
        private void button1_Click(object sender, EventArgs e)
        {
            // Plug in the values from the form.
            tlcBrowser.Document.All["login"].SetAttribute("value", BBYuserName.Text);
            tlcBrowser.Document.All["password"].SetAttribute("value", BBYpassWord.Text);

            // Find and click the login link
            foreach (HtmlElement curElement in tlcBrowser.Document.GetElementsByTagName("button"))
            {
                if (curElement.GetAttribute("classname").Equals("inforFormButton default"))
                    curElement.InvokeMember("click");
            }
        }

        // Scape the schedule.
        private void scrapeButton_Click(object sender, EventArgs e)
        {
            // Turn the scrape button off, since clicking it twice under any circumstance will cause sadness.
            scrapeButton.Enabled = false;

            // Grab current month and year
            foreach (HtmlElement curElement in tlcBrowser.Document.GetElementsByTagName("span"))
            {
                if (curElement.GetAttribute("classname").Equals("pageTitle"))
                {
                    string rawMonthYear = curElement.InnerText;
                    rawYear = rawMonthYear.Substring(rawMonthYear.Length - 4);
                    rawMonth = rawMonthYear.Substring(0, rawMonthYear.Length - 5);
                }
            }

            // Grab shifts from days that are either today or in the future.
            foreach (HtmlElement curElement in tlcBrowser.Document.GetElementsByTagName("td"))
            {
                if (curElement.GetAttribute("classname").Equals("calendarCellRegularCurrent") || curElement.GetAttribute("classname").Equals("calendarCellRegularFuture"))
                {
                    if (curElement.InnerText.Contains("OFF"))
                        continue;
                    // We insert a ":00" so that the time is 10:15:00 PM instead of 10:15 PM, this lets us use DateTime.Parse() later.
                    rawShifts.Add(curElement.InnerText.Substring(0, 13).Replace(System.Environment.NewLine,"").Insert(8,":00"));
                }
            }

            // Dump to the readout to the textbox so the user can verify it was scraped correctly.
            scheduleReadout.Text += rawMonth + " " + rawYear + "\n";
            foreach (string entry in rawShifts)
                scheduleReadout.Text += entry + "\n";

            // Now that we've scraped, we are allowed to export.
            exportButton.Enabled = true;
        }

        // Create and save our .ics file.
        private void exportButton_Click(object sender, EventArgs e)
        {
            // Make a list of events, setting the output cal to the empty one we made in the contructor.
            UniqueComponentList<Event> events = new UniqueComponentList<Event>(icsResult);

            // Step through our list of scraped shifts.
            foreach (string shift in rawShifts)
            {
                // Make a new DateTime object, and have it parse the string.
                // We add in the year and month we scraped earlier, along with some spaces for formatting.
                // We also adjust the new DateTime by the offset the user chose on the form, for timezone shifting.
                DateTime datShift = DateTime.Parse(rawYear + " " + rawMonth + " " + shift).AddHours((int)tlcTimeShift.Value);

                // Make a new event, using the DateTime we just magic'd up.
                var evt = new Event();
                evt.Summary = eventNameTextBox.Text; // Get event name
                evt.Start = new iCalDateTime(datShift);
                // Eight hour shifts are the norm, so just assume the shift is eight hours.
                // I know not every shift is, but oh well.
                evt.Duration = new TimeSpan(8, 0, 0); 
                events.Add(evt); // Add this newly created event to the events list.  This will make it part of our calendar automagically.
            }
 
            // Create a serializer and have it do its voodoo.
            iCalendarSerializer serializer = new iCalendarSerializer(icsResult);
            serializer.Serialize(icsResult, rawMonth.ToString() + ".ics");
            Application.Exit();
        }
    }
}
