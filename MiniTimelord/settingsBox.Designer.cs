namespace MiniTimelord
{
    partial class settingsBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsBox));
            this.scrollCheck = new System.Windows.Forms.CheckBox();
            this.studioTitleCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.newsCheck = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.deadAirAlertCheck = new System.Windows.Forms.CheckBox();
            this.jukeboxAlertCheck = new System.Windows.Forms.CheckBox();
            this.updateLabel = new System.Windows.Forms.Label();
            this.checkUpdateCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // scrollCheck
            // 
            this.scrollCheck.AutoSize = true;
            this.scrollCheck.Location = new System.Drawing.Point(12, 12);
            this.scrollCheck.Name = "scrollCheck";
            this.scrollCheck.Size = new System.Drawing.Size(260, 21);
            this.scrollCheck.TabIndex = 0;
            this.scrollCheck.Text = "Scroll text that is too long to display?";
            this.scrollCheck.UseVisualStyleBackColor = true;
            // 
            // studioTitleCheck
            // 
            this.studioTitleCheck.AutoSize = true;
            this.studioTitleCheck.Location = new System.Drawing.Point(12, 39);
            this.studioTitleCheck.Name = "studioTitleCheck";
            this.studioTitleCheck.Size = new System.Drawing.Size(204, 21);
            this.studioTitleCheck.TabIndex = 1;
            this.studioTitleCheck.Text = "Show current studio in title?";
            this.studioTitleCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Defaults";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // newsCheck
            // 
            this.newsCheck.AutoSize = true;
            this.newsCheck.Location = new System.Drawing.Point(12, 66);
            this.newsCheck.Name = "newsCheck";
            this.newsCheck.Size = new System.Drawing.Size(94, 21);
            this.newsCheck.TabIndex = 3;
            this.newsCheck.Text = "Do News?";
            this.newsCheck.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(148, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 31);
            this.button4.TabIndex = 6;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // deadAirAlertCheck
            // 
            this.deadAirAlertCheck.AutoSize = true;
            this.deadAirAlertCheck.Location = new System.Drawing.Point(12, 93);
            this.deadAirAlertCheck.Name = "deadAirAlertCheck";
            this.deadAirAlertCheck.Size = new System.Drawing.Size(126, 21);
            this.deadAirAlertCheck.TabIndex = 7;
            this.deadAirAlertCheck.Text = "Alert Dead Air?";
            this.deadAirAlertCheck.UseVisualStyleBackColor = true;
            // 
            // jukeboxAlertCheck
            // 
            this.jukeboxAlertCheck.AutoSize = true;
            this.jukeboxAlertCheck.Location = new System.Drawing.Point(12, 120);
            this.jukeboxAlertCheck.Name = "jukeboxAlertCheck";
            this.jukeboxAlertCheck.Size = new System.Drawing.Size(171, 21);
            this.jukeboxAlertCheck.TabIndex = 8;
            this.jukeboxAlertCheck.Text = "Alert when Jukebox\'d?";
            this.jukeboxAlertCheck.UseVisualStyleBackColor = true;
            // 
            // updateLabel
            // 
            this.updateLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.updateLabel.Location = new System.Drawing.Point(141, 192);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(144, 23);
            this.updateLabel.TabIndex = 9;
            this.updateLabel.Text = "Check for Updates";
            this.updateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateLabel.DoubleClick += new System.EventHandler(this.Label1_DoubleClick);
            // 
            // checkUpdateCheck
            // 
            this.checkUpdateCheck.AutoSize = true;
            this.checkUpdateCheck.Location = new System.Drawing.Point(12, 147);
            this.checkUpdateCheck.Name = "checkUpdateCheck";
            this.checkUpdateCheck.Size = new System.Drawing.Size(238, 21);
            this.checkUpdateCheck.TabIndex = 10;
            this.checkUpdateCheck.Text = "Automatically check for updates?";
            this.checkUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // settingsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 265);
            this.Controls.Add(this.checkUpdateCheck);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.jukeboxAlertCheck);
            this.Controls.Add(this.deadAirAlertCheck);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.newsCheck);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.studioTitleCheck);
            this.Controls.Add(this.scrollCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settingsBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.SettingsBox_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox scrollCheck;
        private System.Windows.Forms.CheckBox studioTitleCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox newsCheck;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox deadAirAlertCheck;
        private System.Windows.Forms.CheckBox jukeboxAlertCheck;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.CheckBox checkUpdateCheck;
    }
}