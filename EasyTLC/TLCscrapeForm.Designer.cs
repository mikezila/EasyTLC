namespace EasyTLC
{
    partial class TLCscrapeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLCscrapeForm));
            this.tlcBrowser = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BBYuserName = new System.Windows.Forms.TextBox();
            this.BBYpassWord = new System.Windows.Forms.TextBox();
            this.scrapeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.scheduleReadout = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.tlcTimeShift = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.namePrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tlcTimeShift)).BeginInit();
            this.SuspendLayout();
            // 
            // tlcBrowser
            // 
            this.tlcBrowser.Location = new System.Drawing.Point(248, 12);
            this.tlcBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.tlcBrowser.Name = "tlcBrowser";
            this.tlcBrowser.ScriptErrorsSuppressed = true;
            this.tlcBrowser.Size = new System.Drawing.Size(856, 534);
            this.tlcBrowser.TabIndex = 1;
            this.tlcBrowser.Url = new System.Uri("http://mytlc.bestbuy.com", System.UriKind.Absolute);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "aNumber / Password";
            // 
            // BBYuserName
            // 
            this.BBYuserName.Location = new System.Drawing.Point(13, 30);
            this.BBYuserName.Name = "BBYuserName";
            this.BBYuserName.Size = new System.Drawing.Size(148, 20);
            this.BBYuserName.TabIndex = 4;
            // 
            // BBYpassWord
            // 
            this.BBYpassWord.Location = new System.Drawing.Point(13, 56);
            this.BBYpassWord.Name = "BBYpassWord";
            this.BBYpassWord.Size = new System.Drawing.Size(148, 20);
            this.BBYpassWord.TabIndex = 5;
            this.BBYpassWord.UseSystemPasswordChar = true;
            // 
            // scrapeButton
            // 
            this.scrapeButton.Location = new System.Drawing.Point(16, 125);
            this.scrapeButton.Name = "scrapeButton";
            this.scrapeButton.Size = new System.Drawing.Size(226, 23);
            this.scrapeButton.TabIndex = 7;
            this.scrapeButton.Text = "Scrape Schedule";
            this.scrapeButton.UseVisualStyleBackColor = true;
            this.scrapeButton.Click += new System.EventHandler(this.scrapeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Click once schedule is on-screen:";
            // 
            // scheduleReadout
            // 
            this.scheduleReadout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheduleReadout.Location = new System.Drawing.Point(12, 177);
            this.scheduleReadout.Name = "scheduleReadout";
            this.scheduleReadout.Size = new System.Drawing.Size(230, 262);
            this.scheduleReadout.TabIndex = 9;
            this.scheduleReadout.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Results";
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(12, 506);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(230, 40);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "Export .ics File";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // tlcTimeShift
            // 
            this.tlcTimeShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlcTimeShift.Location = new System.Drawing.Point(121, 445);
            this.tlcTimeShift.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tlcTimeShift.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.tlcTimeShift.Name = "tlcTimeShift";
            this.tlcTimeShift.Size = new System.Drawing.Size(120, 20);
            this.tlcTimeShift.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Time Shift (Hours)";
            // 
            // namePrefix
            // 
            this.namePrefix.Location = new System.Drawing.Point(121, 472);
            this.namePrefix.Name = "namePrefix";
            this.namePrefix.Size = new System.Drawing.Size(119, 20);
            this.namePrefix.TabIndex = 14;
            this.namePrefix.Text = "Work";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Event Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 558);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.namePrefix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tlcTimeShift);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scheduleReadout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scrapeButton);
            this.Controls.Add(this.BBYpassWord);
            this.Controls.Add(this.BBYuserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tlcBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy TLC (Beta)";
            ((System.ComponentModel.ISupportInitialize)(this.tlcTimeShift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser tlcBrowser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BBYuserName;
        private System.Windows.Forms.TextBox BBYpassWord;
        private System.Windows.Forms.Button scrapeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox scheduleReadout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.NumericUpDown tlcTimeShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox namePrefix;
        private System.Windows.Forms.Label label5;
    }
}

