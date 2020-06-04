namespace MiniTimelord
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hideTimer = new System.Windows.Forms.Timer(this.components);
            this.RedStatus = new System.Windows.Forms.Label();
            this.BlueStatus = new System.Windows.Forms.Label();
            this.JukeboxStatus = new System.Windows.Forms.Label();
            this.StatusOB = new System.Windows.Forms.Label();
            this.StatusWS = new System.Windows.Forms.Label();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.songLabel = new System.Windows.Forms.Label();
            this.songTimer = new System.Windows.Forms.Timer(this.components);
            this.songTimer2 = new System.Windows.Forms.Timer(this.components);
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.WSRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.JBRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.OBRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SBlueRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SRedRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.fullSongLabel = new System.Windows.Forms.Label();
            this.currentShowLabel = new System.Windows.Forms.Label();
            this.nextShowLabel = new System.Windows.Forms.Label();
            this.showTimer = new System.Windows.Forms.Timer(this.components);
            this.studioTitleLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.speechTimer = new System.Windows.Forms.Timer(this.components);
            this.speechRestartTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 300;
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.Text = "lol hi";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("roundabout", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "minitimelord";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // hideTimer
            // 
            this.hideTimer.Enabled = true;
            this.hideTimer.Tick += new System.EventHandler(this.HideTimer_Tick);
            // 
            // RedStatus
            // 
            this.RedStatus.BackColor = System.Drawing.Color.Transparent;
            this.RedStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.RedStatus.Location = new System.Drawing.Point(8, 212);
            this.RedStatus.Name = "RedStatus";
            this.RedStatus.Size = new System.Drawing.Size(55, 34);
            this.RedStatus.TabIndex = 4;
            this.RedStatus.Text = "Studio \r\nRed";
            this.RedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlueStatus
            // 
            this.BlueStatus.AutoSize = true;
            this.BlueStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.BlueStatus.Location = new System.Drawing.Point(83, 214);
            this.BlueStatus.Name = "BlueStatus";
            this.BlueStatus.Size = new System.Drawing.Size(48, 34);
            this.BlueStatus.TabIndex = 5;
            this.BlueStatus.Text = "Studio\r\nBlue";
            this.BlueStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JukeboxStatus
            // 
            this.JukeboxStatus.AutoSize = true;
            this.JukeboxStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.JukeboxStatus.Location = new System.Drawing.Point(145, 221);
            this.JukeboxStatus.Name = "JukeboxStatus";
            this.JukeboxStatus.Size = new System.Drawing.Size(60, 17);
            this.JukeboxStatus.TabIndex = 6;
            this.JukeboxStatus.Text = "Jukebox";
            // 
            // StatusOB
            // 
            this.StatusOB.AutoSize = true;
            this.StatusOB.ForeColor = System.Drawing.Color.DarkGray;
            this.StatusOB.Location = new System.Drawing.Point(232, 221);
            this.StatusOB.Name = "StatusOB";
            this.StatusOB.Size = new System.Drawing.Size(28, 17);
            this.StatusOB.TabIndex = 7;
            this.StatusOB.Text = "OB";
            // 
            // StatusWS
            // 
            this.StatusWS.AutoSize = true;
            this.StatusWS.ForeColor = System.Drawing.Color.DarkGray;
            this.StatusWS.Location = new System.Drawing.Point(292, 214);
            this.StatusWS.Name = "StatusWS";
            this.StatusWS.Size = new System.Drawing.Size(48, 34);
            this.StatusWS.TabIndex = 8;
            this.StatusWS.Text = "Web\r\nStudio";
            this.StatusWS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Interval = 10000;
            this.statusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(0, 62);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(353, 44);
            this.timeLabel.TabIndex = 9;
            this.timeLabel.Text = "!! Time !!";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeTimer
            // 
            this.timeTimer.Enabled = true;
            this.timeTimer.Interval = 1000;
            this.timeTimer.Tick += new System.EventHandler(this.TimeTimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "News";
            // 
            // songLabel
            // 
            this.songLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.songLabel.AutoEllipsis = true;
            this.songLabel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songLabel.Location = new System.Drawing.Point(11, 109);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(330, 25);
            this.songLabel.TabIndex = 13;
            this.songLabel.Text = "!! Current Track !!";
            this.songLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // songTimer
            // 
            this.songTimer.Enabled = true;
            this.songTimer.Interval = 300;
            this.songTimer.Tick += new System.EventHandler(this.SongTimer_Tick);
            // 
            // songTimer2
            // 
            this.songTimer2.Enabled = true;
            this.songTimer2.Interval = 300;
            this.songTimer2.Tick += new System.EventHandler(this.SongTimer2_Tick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.WSRect,
            this.JBRect,
            this.OBRect,
            this.SBlueRect,
            this.SRedRect});
            this.shapeContainer1.Size = new System.Drawing.Size(353, 250);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // WSRect
            // 
            this.WSRect.BorderWidth = 3;
            this.WSRect.Location = new System.Drawing.Point(213, 170);
            this.WSRect.Name = "WSRect";
            this.WSRect.Size = new System.Drawing.Size(50, 31);
            // 
            // JBRect
            // 
            this.JBRect.BorderWidth = 3;
            this.JBRect.Location = new System.Drawing.Point(107, 170);
            this.JBRect.Name = "JBRect";
            this.JBRect.Size = new System.Drawing.Size(50, 31);
            // 
            // OBRect
            // 
            this.OBRect.BorderWidth = 3;
            this.OBRect.Location = new System.Drawing.Point(160, 170);
            this.OBRect.Name = "OBRect";
            this.OBRect.Size = new System.Drawing.Size(50, 31);
            // 
            // SBlueRect
            // 
            this.SBlueRect.BorderWidth = 3;
            this.SBlueRect.Location = new System.Drawing.Point(54, 170);
            this.SBlueRect.Name = "SBlueRect";
            this.SBlueRect.Size = new System.Drawing.Size(50, 31);
            // 
            // SRedRect
            // 
            this.SRedRect.BorderWidth = 3;
            this.SRedRect.Location = new System.Drawing.Point(1, 170);
            this.SRedRect.Name = "SRedRect";
            this.SRedRect.Size = new System.Drawing.Size(50, 31);
            // 
            // fullSongLabel
            // 
            this.fullSongLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.fullSongLabel.Location = new System.Drawing.Point(4, 178);
            this.fullSongLabel.Name = "fullSongLabel";
            this.fullSongLabel.Size = new System.Drawing.Size(66, 17);
            this.fullSongLabel.TabIndex = 16;
            this.fullSongLabel.Text = "Unknown";
            this.fullSongLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentShowLabel
            // 
            this.currentShowLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentShowLabel.AutoEllipsis = true;
            this.currentShowLabel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentShowLabel.Location = new System.Drawing.Point(15, 139);
            this.currentShowLabel.Name = "currentShowLabel";
            this.currentShowLabel.Size = new System.Drawing.Size(326, 25);
            this.currentShowLabel.TabIndex = 17;
            this.currentShowLabel.Text = "!! Current Show !!";
            this.currentShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextShowLabel
            // 
            this.nextShowLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextShowLabel.AutoEllipsis = true;
            this.nextShowLabel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextShowLabel.Location = new System.Drawing.Point(15, 168);
            this.nextShowLabel.Name = "nextShowLabel";
            this.nextShowLabel.Size = new System.Drawing.Size(326, 25);
            this.nextShowLabel.TabIndex = 18;
            this.nextShowLabel.Text = "!! Next Show !!";
            this.nextShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.nextShowLabel, "test tip");
            // 
            // showTimer
            // 
            this.showTimer.Enabled = true;
            this.showTimer.Interval = 300;
            this.showTimer.Tick += new System.EventHandler(this.ShowTimer_Tick);
            // 
            // studioTitleLabel
            // 
            this.studioTitleLabel.Font = new System.Drawing.Font("roundabout", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studioTitleLabel.Location = new System.Drawing.Point(-1, 18);
            this.studioTitleLabel.Name = "studioTitleLabel";
            this.studioTitleLabel.Size = new System.Drawing.Size(353, 42);
            this.studioTitleLabel.TabIndex = 19;
            this.studioTitleLabel.Text = "!! studio !!";
            this.studioTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.studioTitleLabel.Click += new System.EventHandler(this.StudioTitleLabel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500000000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Settings";
            this.label4.DoubleClick += new System.EventHandler(this.Label4_DoubleClick_1);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(302, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Close";
            this.label2.DoubleClick += new System.EventHandler(this.Label2_DoubleClick_1);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 10000;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // speechTimer
            // 
            this.speechTimer.Interval = 1000;
            this.speechTimer.Tick += new System.EventHandler(this.SpeechTimer_Tick);
            // 
            // speechRestartTimer
            // 
            this.speechRestartTimer.Enabled = true;
            this.speechRestartTimer.Interval = 30000;
            this.speechRestartTimer.Tick += new System.EventHandler(this.SpeechRestartTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 250);
            this.ControlBox = false;
            this.Controls.Add(this.studioTitleLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.currentShowLabel);
            this.Controls.Add(this.nextShowLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusWS);
            this.Controls.Add(this.StatusOB);
            this.Controls.Add(this.JukeboxStatus);
            this.Controls.Add(this.BlueStatus);
            this.Controls.Add(this.RedStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullSongLabel);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniTimelord";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer hideTimer;
        private System.Windows.Forms.Label RedStatus;
        private System.Windows.Forms.Label BlueStatus;
        private System.Windows.Forms.Label JukeboxStatus;
        private System.Windows.Forms.Label StatusOB;
        private System.Windows.Forms.Label StatusWS;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timeTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.Timer songTimer;
        private System.Windows.Forms.Timer songTimer2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape WSRect;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape OBRect;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape JBRect;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape SBlueRect;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape SRedRect;
        private System.Windows.Forms.Label fullSongLabel;
        private System.Windows.Forms.Label currentShowLabel;
        private System.Windows.Forms.Label nextShowLabel;
        private System.Windows.Forms.Timer showTimer;
        private System.Windows.Forms.Label studioTitleLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer speechTimer;
        private System.Windows.Forms.Timer speechRestartTimer;
    }
}

