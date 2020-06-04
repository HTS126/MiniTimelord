using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;
using System.Net.Http;
using System.Threading;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic.PowerPacks;
using System.Speech.Recognition;
using System.Speech.Synthesis;


//silence: https://www.dropbox.com/s/bihob6vwklenjy3/issilence.txt?dl=1
//selector: https://www.dropbox.com/s/01qq2aa2raeehnu/selector.txt?dl=1

//silence: https://ury.org.uk/api/v2/selector/issilence?api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK
//selector: https://ury.org.uk/api/v2/selector/statusattime?api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK

namespace MiniTimelord
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer voice = new SpeechSynthesizer();
        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();
        int RecTimeOut = 0;


        public Form1()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static int lastSelected = 0;
            public static Boolean silenceAlerted = false;
            public static Boolean deadAirShortTitle = false;
            public static Boolean isNews = false;
            public static Boolean isIRN = false;
            public static Boolean isListening = false;
            public static DateTime lastStudioChange = new DateTime();
            public static string currentVersion = "";
            public static string newestVersion = "";
            public static long lastSecond = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            if (Properties.Settings.Default.settingsUpgradeRequired == true)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.settingsUpgradeRequired = false;
                Properties.Settings.Default.Save();
            }



            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Play Online Feed", "Play A M Feed", "Play News Feed", "Play O B Feed", "Play Studio Red Feed", "Play Studio Blue Feed", "Play Web Studio Feed", "Play Jukebox Feed", "Stop Playing", "Stop"))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            //_recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Okay Time Lord"))));
            startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startListening_SpeechRecognized);

            if(Properties.Settings.Default.voiceActivationEnabled == true)
            {
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                
            }
            

        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Stop Playing" || speech == "Stop")
            {
                Globals.isListening = false;
                var sound = new System.Media.SoundPlayer(Properties.Resources.done);
                sound.Play();
                refreshTimer.Interval = 300;
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                try
                {
                    foreach (var process in Process.GetProcessesByName("winamp"))
                    {
                        process.Kill();
                    }
                }
                catch
                {
                    //Nothing
                }
            }
            if (speech == "Play Online Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                voice.SpeakAsync("Playing Online Feed");
                _recognizer.RecognizeAsyncCancel();

                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                this.Visible = false;
                try
                {
                    Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/live-high");
                }
                catch
                {
                    voice.SpeakAsync("Error: Could not open Win Amp");
                }
                
            }
            if (speech == "Play A M Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                voice.SpeakAsync("Playing A M Feed");
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                this.Visible = false;
                try
                {
                    Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/am");
                }
                catch
                {
                    voice.SpeakAsync("Error: Could not open Win Amp");
                }
            }
            if (speech == "Play News Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                voice.SpeakAsync("Playing News Feed");
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                this.Visible = false;
                try
                {
                    Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/news");
                }
                catch
                {
                    voice.SpeakAsync("Error: Could not open Win Amp");
                }
            }
            if (speech == "Play O B Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                if (StatusOB.ForeColor == Color.Green || StatusOB.ForeColor == Color.DarkOrange)
                {
                    voice.SpeakAsync("Playing O B Feed");
                    this.Visible = false;
                    try
                    {
                        Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/OB-Line");
                    }
                    catch
                    {
                        voice.SpeakAsync("Error: Could not open Win Amp");
                    }
                }
                else
                {
                    voice.SpeakAsync("O B Feed is Not Active");
                }
            }
            if (speech == "Play Studio Red Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                if (RedStatus.ForeColor == Color.Green || RedStatus.ForeColor == Color.DarkOrange)
                {
                    voice.SpeakAsync("Playing Feed from Studio Red");
                    this.Visible = false;
                    try
                    {
                        Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/studio-red");
                    }
                    catch
                    {
                        voice.SpeakAsync("Error: Could not open Win Amp");
                    }
                }
                else
                {
                    voice.SpeakAsync("Studio Red is not Powered On");
                }
            }
            if (speech == "Play Studio Blue Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                if (BlueStatus.ForeColor == Color.Green || BlueStatus.ForeColor == Color.DarkOrange)
                {
                    voice.SpeakAsync("Playing Feed from Studio Blue");
                    this.Visible = false;
                    try
                    {
                        Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/studio-blue");
                    }
                    catch
                    {
                        voice.SpeakAsync("Error: Could not open Win Amp");
                    }
                }
                else
                {
                    voice.SpeakAsync("Studio Blue is not Powered On");
                }
            }
            if (speech == "Play Web Studio Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                if (StatusWS.ForeColor == Color.Green || StatusWS.ForeColor == Color.DarkOrange)
                {
                    voice.SpeakAsync("Playing Web Studio Feed");
                    this.Visible = false;
                    try
                    {
                        Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/webstudio");
                    }
                    catch
                    {
                        voice.SpeakAsync("Error: Could not open Win Amp");
                    }
                }
                else
                {
                    voice.SpeakAsync("Web Studio is Not Active");
                }
            }
            if (speech == "Play Jukebox Feed")
            {
                Globals.isListening = false;
                refreshTimer.Interval = 300;
                _recognizer.RecognizeAsyncCancel();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                speechTimer.Enabled = false;
                RecTimeOut = 0;
                if (JukeboxStatus.ForeColor == Color.Green || JukeboxStatus.ForeColor == Color.DarkOrange)
                {
                    voice.SpeakAsync("Playing Jukebox Feed");
                    this.Visible = false;
                    try
                    {
                        Process.Start("C:\\Program Files (x86)\\Winamp\\winamp.exe", "http://dolby.ury.york.ac.uk:7070/jukebox");
                    }
                    catch
                    {
                        voice.SpeakAsync("Error: Could not open Win Amp");
                    }
                }
                else
                {
                    voice.SpeakAsync("Jukebox is Not Active");
                }
            }
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void startListening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if(speech == "Okay Time Lord" && e.Result.Confidence == 0.8)
            {

                Globals.isListening = true;
                refreshTimer.Interval = 300;
                startListening.RecognizeAsyncCancel();
                speechTimer.Enabled = true;
                //voice.SpeakAsync("Ready");
                var sound = new System.Media.SoundPlayer(Properties.Resources.ping);
                sound.Play();
                try
                {
                    _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            string minutenow = DateTime.Now.ToString("mm");
            string secondnow = DateTime.Now.ToString("ss");
            if (Properties.Settings.Default.showSelectorTitle == true)
            {
                studioTitleLabel.Visible = true;
                label1.Visible = false;
            }
            else
            {
                studioTitleLabel.Visible = false;
                label1.Visible = true;
            }
            try
            {
                refreshTimer.Interval = 3000;
                WebClient silence = new WebClient();
                string silenceFullResponse = silence.DownloadString("https://ury.org.uk/api/v2/selector/issilence?api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK");
                //string silenceFullResponse = silence.DownloadString("https://www.dropbox.com/s/bihob6vwklenjy3/issilence.txt?dl=1");
                var silenceResponseTree = JObject.Parse(silenceFullResponse);
                int currentSilence = (int)silenceResponseTree["payload"];
                if (currentSilence > 5 && Properties.Settings.Default.alertDeadAir == true)
                {
                    if(currentSilence >= 25)
                    {
                        trayIcon.Icon = MiniTimelord.Properties.Resources.DeadAir;
                        if (Globals.silenceAlerted == false)
                        {
                            Globals.silenceAlerted = true;
                            trayIcon.BalloonTipTitle = "DEAD AIR DETECTED!!";
                            trayIcon.BalloonTipText = "Silence has been detected on URY! Please fix!!";
                            trayIcon.ShowBalloonTip(1800000);
                            studioTitleLabel.Text = "dead air";
                            studioTitleLabel.ForeColor = Color.Red;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastSelected = 99;
                        }
                    
                    }
                    else
                    {
                        if (Globals.deadAirShortTitle == false)
                        {
                            studioTitleLabel.Text = "dead air";
                            studioTitleLabel.ForeColor = Color.DarkOrange;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastSelected = 99;
                        }
                        
                    }
                }
                else if(Globals.isListening == true)
                {
                    trayIcon.Icon = MiniTimelord.Properties.Resources.listening;
                    trayIcon.Text = "Listening for Voice Command...";
                    studioTitleLabel.Text = "listening...";
                    studioTitleLabel.ForeColor = Color.Turquoise;
                    studioTitleLabel.Font = new Font("roundabout", 20);
                    Globals.lastSelected = 98;
                }
                else
                {

                    Globals.silenceAlerted = false;
                    Globals.deadAirShortTitle = false;
                    WebClient selector = new WebClient();
                    string jsonResponseStudio = selector.DownloadString("https://ury.org.uk/api/v2/selector/statusattime?api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK");
                    var jsonTreeStudio = JObject.Parse(jsonResponseStudio);
                    int currentStudio = (int)jsonTreeStudio["payload"]["studio"];
                    if (currentStudio == 1)
                    {
                        if (Globals.lastSelected != 1)
                        {
                            if (! Globals.isIRN)
                            {
                                trayIcon.Icon = MiniTimelord.Properties.Resources.SRed;
                                trayIcon.Text = "Studio Red is On Air";
                                Globals.lastSelected = 1;
                            }
                            studioTitleLabel.Text = "studio red";
                            studioTitleLabel.ForeColor = Color.DarkRed;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastStudioChange = DateTime.Now;
                            statusTimer.Interval = 300;
                        }
                    }
                    else if (currentStudio == 2)
                    {
                        if (Globals.lastSelected != 2)
                        {
                            if(!Globals.isIRN)
                            {
                                trayIcon.Icon = MiniTimelord.Properties.Resources.SBlue;
                                trayIcon.Text = "Studio Blue is On Air";
                                Globals.lastSelected = 2;
                            }
                            
                            studioTitleLabel.Text = "studio blue";
                            studioTitleLabel.ForeColor = Color.DarkBlue;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastStudioChange = DateTime.Now;
                            statusTimer.Interval = 300;
                        }
                    }
                    else if (currentStudio == 3)
                    {
                        if (Globals.lastSelected != 3)
                        {
                            string currentShowJB = "";
                            try
                            {
                                WebClient showJBClient = new WebClient();
                                string jsonJBResponse = showJBClient.DownloadString("https://ury.org.uk/api/v2/timeslot/currentandnext?n=2&filter%5B%5D=1&filter%5B%5D=2&api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK");
                                var jsonJBTree = JObject.Parse(jsonJBResponse);
                                currentShowJB = (string)jsonJBTree["payload"]["current"]["title"];
                            }
                            catch
                            {
                                currentShowJB = "URY Jukebox";
                            }
                            

                            if(currentShowJB != "URY Jukebox")
                            {
                                if (Properties.Settings.Default.alertJukebox == true && minutenow != "59" && minutenow != "00" && minutenow != "01" && minutenow != "02" && minutenow != "03" && Globals.lastSelected != 8 && Globals.lastSelected != 9 && Globals.lastSelected != 0 && Globals.lastSelected != 10 && Globals.lastSelected != 99 && Globals.lastSelected != 98)
                                {

                                    trayIcon.BalloonTipTitle = "Someone Got Jukebox'd!";
                                    trayIcon.BalloonTipText = "URY has been switched to Jukebox when someone was on air!";
                                    trayIcon.ShowBalloonTip(5000);
                                }
                            }

                            
                            if(!Globals.isIRN)
                            {
                                trayIcon.Icon = MiniTimelord.Properties.Resources.Jukebox;
                                trayIcon.Text = "Jukebox is On Air";
                                Globals.lastSelected = 3;
                            }
                            
                            studioTitleLabel.Text = "jukebox";
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastStudioChange = DateTime.Now;
                            studioTitleLabel.ForeColor = Color.Green;
                            statusTimer.Interval = 300;
                        }
                    }
                    else if (currentStudio == 4)
                    {
                        if (Globals.lastSelected != 4)
                        {
                            if(!Globals.isIRN)
                            {
                                trayIcon.Icon = MiniTimelord.Properties.Resources.OB;
                                trayIcon.Text = "Outside Broadcast";
                                Globals.lastSelected = 4;
                            }
                            
                            studioTitleLabel.Text = "outside broadcast";
                            studioTitleLabel.ForeColor = Color.DarkViolet;
                            studioTitleLabel.Font = new Font("roundabout", 14);
                            Globals.lastStudioChange = DateTime.Now;
                            statusTimer.Interval = 300;
                        }
                    }
                    else if (currentStudio == 5)
                    {
                        if (Globals.lastSelected != 5)
                        {
                            if (!Globals.isIRN)
                            {
                                trayIcon.Icon = MiniTimelord.Properties.Resources.WS;
                                trayIcon.Text = "WebStudio is On Air";
                                Globals.lastSelected = 5;
                            }
                            
                            studioTitleLabel.Text = "webstudio";
                            studioTitleLabel.ForeColor = Color.MediumOrchid;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastStudioChange = DateTime.Now;
                            statusTimer.Interval = 300;
                        }
                    }
                    else if (currentStudio == 8)
                    {
                        if (Globals.lastSelected != 8)
                        {
                            trayIcon.Icon = MiniTimelord.Properties.Resources.OffAir;
                            trayIcon.Text = "URY is Off Air";
                            Globals.lastSelected = 8;
                            studioTitleLabel.Text = "off air";
                            studioTitleLabel.ForeColor = Color.Goldenrod;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastStudioChange = DateTime.Now;
                            statusTimer.Interval = 300;
                        }
                    }
                    else
                    {
                        if (Globals.lastSelected != 9)
                        {
                            if(!Globals.isIRN)
                            {
                                trayIcon.Icon = MiniTimelord.Properties.Resources.Unknown;
                                trayIcon.Text = "Unknown Source is On Air";
                                Globals.lastSelected = 9;
                            }
                            
                            studioTitleLabel.Text = "unknown";
                            studioTitleLabel.ForeColor = Color.Black;
                            studioTitleLabel.Font = new Font("roundabout", 20);
                            Globals.lastStudioChange = DateTime.Now;
                            statusTimer.Interval = 300;
                        }
                    }
                }
            }
            catch
            {
                if (Globals.lastSelected != 10)
                {
                    if (!Globals.isIRN)
                    {
                        trayIcon.Icon = MiniTimelord.Properties.Resources.Unknown;
                        trayIcon.Text = "Could Not Update Source";
                        Globals.lastSelected = 10;
                    }
                    
                    studioTitleLabel.Text = "no connection";
                    studioTitleLabel.ForeColor = Color.Black;
                    studioTitleLabel.Font = new Font("roundabout", 20);
                }
            }

            
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.showSelectorTitle = true;
            Properties.Settings.Default.Save();
            label1.Visible = false;
            studioTitleLabel.Visible = true;

        }

        private void TrayIcon_Click(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            hideTimer.Enabled = false;
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {

                WebClient status = new WebClient();
                string statusFullResponse = status.DownloadString("https://ury.org.uk/api/v2/selector/statusattime?api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK");
                //string statusFullResponse = status.DownloadString("https://www.dropbox.com/s/01qq2aa2raeehnu/selector.txt?dl=1");
                //current
                var statusFullTree = JObject.Parse(statusFullResponse);
                int currentStudio = (int)statusFullTree["payload"]["studio"];


                //red
                Boolean redStatus = (Boolean)statusFullTree["payload"]["s1power"];
                if (redStatus == true)
                {
                    if (currentStudio == 1)
                    {
                        RedStatus.ForeColor = Color.Green;
                        SRedRect.BorderColor = Color.Green;
                    }
                    else
                    {
                        RedStatus.ForeColor = Color.DarkOrange;
                        SRedRect.BorderColor = Color.DarkOrange;
                    }
                }
                else
                {
                    if(RedStatus.ForeColor == Color.Green || RedStatus.ForeColor == Color.DarkOrange)
                    {
                        RedStatus.ForeColor = Color.Red;
                        SRedRect.BorderColor = Color.Red;
                    }
                    else
                    {
                        RedStatus.ForeColor = Color.Black;
                        SRedRect.BorderColor = Color.Black;
                    }
                }

                //blue
                Boolean blueStatus = (Boolean)statusFullTree["payload"]["s2power"];
                if (blueStatus == true)
                {
                    if (currentStudio == 2)
                    {
                        BlueStatus.ForeColor = Color.Green;
                        SBlueRect.BorderColor = Color.Green;
                    }
                    else
                    {
                        BlueStatus.ForeColor = Color.DarkOrange;
                        SBlueRect.BorderColor = Color.DarkOrange;
                    }
                }
                else
                {
                    if (BlueStatus.ForeColor == Color.Green || BlueStatus.ForeColor == Color.DarkOrange)
                    {
                        BlueStatus.ForeColor = Color.Red;
                        SBlueRect.BorderColor = Color.Red;
                    }
                    else
                    {
                        BlueStatus.ForeColor = Color.Black;
                        SBlueRect.BorderColor = Color.Black;
                    }
                }

                //jukebox
                Boolean JBStatus = (Boolean)statusFullTree["payload"]["s3power"];
                if (JBStatus == true)
                {
                    if (currentStudio == 3)
                    {
                        JukeboxStatus.ForeColor = Color.Green;
                        JBRect.BorderColor = Color.Green;
                    }
                    else
                    {
                        JukeboxStatus.ForeColor = Color.DarkOrange;
                        JBRect.BorderColor = Color.DarkOrange;
                    }
                }
                else
                {
                    if (JukeboxStatus.ForeColor == Color.Green || JukeboxStatus.ForeColor == Color.DarkOrange)
                    {
                        JukeboxStatus.ForeColor = Color.Red;
                        JBRect.BorderColor = Color.Red;
                    }
                    else
                    {
                        JukeboxStatus.ForeColor = Color.Black;
                        JBRect.BorderColor = Color.Black;
                    }
                }

                //OB
                Boolean OBStatus = (Boolean)statusFullTree["payload"]["s4power"];
                if (OBStatus == true)
                {
                    if (currentStudio == 4)
                    {
                        StatusOB.ForeColor = Color.Green;
                        OBRect.BorderColor = Color.Green;
                    }
                    else
                    {
                        StatusOB.ForeColor = Color.DarkOrange;
                        OBRect.BorderColor = Color.DarkOrange;
                    }
                }
                else
                {
                    if (StatusOB.ForeColor == Color.Green || StatusOB.ForeColor == Color.DarkOrange)
                    {
                        StatusOB.ForeColor = Color.Red;
                        OBRect.BorderColor = Color.Red;
                    }
                    else
                    {
                        StatusOB.ForeColor = Color.Black;
                        OBRect.BorderColor = Color.Black;
                    }
                }

                //WS
                Boolean WSStatus = (Boolean)statusFullTree["payload"]["s5power"];
                if (WSStatus == true)
                {
                    if (currentStudio == 5)
                    {
                        StatusWS.ForeColor = Color.Green;
                        WSRect.BorderColor = Color.Green;
                    }
                    else
                    {
                        StatusWS.ForeColor = Color.DarkOrange;
                        WSRect.BorderColor = Color.DarkOrange;
                    }
                }
                else
                {
                    if (StatusWS.ForeColor == Color.Green || StatusWS.ForeColor == Color.DarkOrange)
                    {
                        StatusWS.ForeColor = Color.Red;
                        WSRect.BorderColor = Color.Red;
                    }
                    else
                    {
                        StatusWS.ForeColor = Color.Black;
                        WSRect.BorderColor = Color.Black;
                    }
                }
                statusTimer.Interval = 10000;
            }
            catch
            {
                RedStatus.ForeColor = Color.DarkGray;
                BlueStatus.ForeColor = Color.DarkGray;
                JukeboxStatus.ForeColor = Color.DarkGray;
                StatusOB.ForeColor = Color.DarkGray;
                StatusWS.ForeColor = Color.DarkGray;
                SRedRect.BorderColor = Color.Black;
                SBlueRect.BorderColor = Color.Black;
                JBRect.BorderColor = Color.Black;
                OBRect.BorderColor = Color.Black;
                WSRect.BorderColor = Color.Black;
            }
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            }
        }

        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            long timeSecNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (Globals.lastSecond < (timeSecNow - 10))
            {
                if (Properties.Settings.Default.voiceActivationEnabled == true)
                {
                    try
                    {
                        startListening.RecognizeAsync(RecognizeMode.Multiple);
                    }
                    catch
                    {

                    }
                }
                Globals.lastSecond = timeSecNow;
            }
            else
            {
                Globals.lastSecond = timeSecNow;
            }



            if (Properties.Settings.Default.voiceActivationEnabled == false)
            {
                _recognizer.RecognizeAsyncCancel();
                startListening.RecognizeAsyncCancel();
            }


            string hournow = DateTime.Now.ToString("HH");
            string minutenow = DateTime.Now.ToString("mm");
            string secondnow = DateTime.Now.ToString("ss");
            int secondnowint = Int32.Parse(secondnow);
            int minutenowint = Int32.Parse(minutenow);
            if (Globals.lastSelected == 8)
            {
                Globals.isNews = false;
                Globals.isIRN = false;
            }
            else if (Properties.Settings.Default.doNews == false)
            {
                Globals.isNews = false;
                Globals.isIRN = false;
            }
            else
            {
                Globals.isNews = (minutenowint < 2 || (minutenowint == 59 && secondnowint >= 15));
                Globals.isIRN = (minutenowint < 2);
            }
            
            if(hournow == "13" && minutenow == "50")
            {
                timeLabel.Text = "Merry 1350!";
            }

            else if(Globals.lastSelected != 8)
            {
                if (Globals.isNews)
                {
                    if (Globals.lastSelected != 20 && Globals.isListening == false && Globals.lastSelected != 99)
                    {
                        if (minutenowint < 2)
                        {
                            Globals.lastSelected = 20;
                            trayIcon.Icon = MiniTimelord.Properties.Resources.IRN;
                            trayIcon.Text = "URY News";
                        }
                        
                    }
                    if (minutenowint == 59)
                    {
                        if (secondnowint < 45)
                        {
                            timeLabel.Text = "News Intro in " + (45 - secondnowint);
                        }
                        else if (secondnowint <= 52)
                        {
                            timeLabel.Text = (52 - secondnowint) + " until Voice Over";
                        }
                        else
                        {
                            timeLabel.Text = "News in " + (60 - secondnowint);
                        }
                    }
                    else if (minutenowint == 0)
                    {
                        timeLabel.Text = "URY News";
                    }
                    else
                    {
                        timeLabel.Text = "News Ends in " + (60 - secondnowint);
                    }
                }
                else if (minutenow == "02" && secondnow == "00")
                {
                    timeLabel.Text = hournow + ":" + minutenow + ":" + secondnow;
                    refreshTimer.Interval = 300;
                }
                else
                {
                    timeLabel.Text = hournow + ":" + minutenow + ":" + secondnow;
                }
            }
            else
            {
                timeLabel.Text = hournow + ":" + minutenow + ":" + secondnow;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            trayIcon.Visible = false;
        }





        private void Label2_DoubleClick_1(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Do you want to quit MiniTimelord?", "Exit?", buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }



        private void SongTimer_Tick(object sender, EventArgs e)
        {
            
            try
            {
                WebClient songClient = new WebClient();
                string jsonResponse = songClient.DownloadString("https://audio.ury.org.uk/status-json.xsl");
                var jsonTree = JObject.Parse(jsonResponse);
                JToken sources = jsonTree["icestats"]["source"];
                string track = "";
                int length = sources.Count();
                Boolean gotTrack = false;
                for (int k = 0; k < length; k++)
                {
                    if (gotTrack == false)
                    {
                        string sourceString = sources[k]["listenurl"].ToString();
                        if (sourceString.IndexOf("live-high") >= 0)
                        {
                            track = (string)sources[k]["title"];
                            
                            if(! track.Contains("- URY"))
                            {
                                fullSongLabel.Text = track;
                                songLabel.UseMnemonic = false;
                                songLabel.Text = "Now Playing: " + fullSongLabel.Text;
                                toolTip1.SetToolTip(songLabel, songLabel.Text);
                                if (songLabel.Text.Length > 43)
                                {
                                    if(Properties.Settings.Default.doTextScroll == true)
                                    {
                                        songLabel.Text = songLabel.Text + " ::: ";
                                    }
                                    
                                }
                            }
                            else
                            {
                                songLabel.UseMnemonic = false;
                                songLabel.Text = "Last Played: " + fullSongLabel.Text;
                                toolTip1.SetToolTip(songLabel, songLabel.Text);
                                if (songLabel.Text.Length > 43)
                                {
                                    if (Properties.Settings.Default.doTextScroll == true)
                                    {
                                        songLabel.Text = songLabel.Text + " ::: ";
                                    }
                                }
                            }

                            gotTrack = true;
                        }
                    }
                }
                songTimer.Interval = 20000;
            }
            catch
            {
                songLabel.UseMnemonic = false;
                songLabel.Text = "Last Played: " + fullSongLabel.Text;
                toolTip1.SetToolTip(songLabel, songLabel.Text);
                if (songLabel.Text.Length > 43)
                {
                    if (Properties.Settings.Default.doTextScroll == true)
                    {
                        songLabel.Text = songLabel.Text + " ::: ";
                    }
                }
                songTimer.Interval = 20000;
            }
            
        }

        private void SongTimer2_Tick(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.doTextScroll == true)
            {
                if (songLabel.Text.Length > 43)
                {
                    songLabel.Text = (songLabel.Text.Substring((songLabel.Text.Length - (songLabel.Text.Length - 1))) + songLabel.Text.Substring(0, 1));
                }

                if (currentShowLabel.Text.Length > 43)
                {
                    currentShowLabel.Text = (currentShowLabel.Text.Substring((currentShowLabel.Text.Length - (currentShowLabel.Text.Length - 1))) + currentShowLabel.Text.Substring(0, 1));
                }

                if (nextShowLabel.Text.Length > 43)
                {
                    nextShowLabel.Text = (nextShowLabel.Text.Substring((nextShowLabel.Text.Length - (nextShowLabel.Text.Length - 1))) + nextShowLabel.Text.Substring(0, 1));
                }
            }
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            showTimer.Interval = 30000;
            try
            {
                WebClient showClient = new WebClient();
                string jsonResponse = showClient.DownloadString("https://ury.org.uk/api/v2/timeslot/currentandnext?n=2&filter%5B%5D=1&filter%5B%5D=2&api_key=9C4KCqywpDfzIk7OEhYO3tOjDJWftg2sZ65fKT5fTGCWvshnz5tinVt1MiqvETM4eZYDtQbRs13GoTCNB8HTsmQQlcDwFmRo8Xw3uHQoycYkumyTVGdXbxtt1S2Ow7RFbK");
                var jsonTree = JObject.Parse(jsonResponse);
                string currentShow = (string)jsonTree["payload"]["current"]["title"];
                string nextShow = (string)jsonTree["payload"]["next"][0]["title"];
                string thenShow = (string)jsonTree["payload"]["next"][1]["title"];
                int nextStartTime = (int)jsonTree["payload"]["next"][0]["start_time"];
                int thenStartTime = (int)jsonTree["payload"]["next"][1]["start_time"];
                int thenEndTime = (int)jsonTree["payload"]["next"][1]["end_time"];
                DateTime nextStartDT = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                nextStartDT = nextStartDT.AddSeconds(nextStartTime).ToLocalTime();
                DateTime thenStartDT = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                thenStartDT = thenStartDT.AddSeconds(thenStartTime).ToLocalTime();
                DateTime thenEndDT = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                thenEndDT = thenEndDT.AddSeconds(thenEndTime).ToLocalTime();
                string nowToolTip = "";
                string nextToolTip = "";

                if (currentShow == "URY Jukebox")
                {
                    currentShowLabel.Text = "Next: " + nextShow;
                    nextShowLabel.Text = "Then: " + thenShow;
                    nowToolTip = "Next: " + nextShow + " at " + nextStartDT.ToString("HH:mm");
                    nextToolTip = "Then: " + thenShow + " from " + thenStartDT.ToString("HH:mm") + " until " + thenEndDT.ToString("HH:mm");
                }
                else
                {
                    currentShowLabel.Text = "Now: " + currentShow;
                    nextShowLabel.Text = "Next: " + nextShow;
                    nowToolTip = "Now: " + currentShow;
                    nextToolTip = "Next: " + nextShow + " at " + nextStartDT.ToString("HH:mm") + ".\nThen: " + thenShow + " from " + thenStartDT.ToString("HH:mm") + " until " + thenEndDT.ToString("HH:mm") + ".";

                }
                toolTip1.SetToolTip(currentShowLabel, nowToolTip);
                toolTip1.SetToolTip(nextShowLabel, nextToolTip);


                if (currentShowLabel.Text.Length > 40)
                {
                    if(Properties.Settings.Default.doTextScroll == true)
                    {
                        currentShowLabel.Text = currentShowLabel.Text + " ::: ";
                    }
                    
                }

                if (nextShowLabel.Text.Length > 40)
                {
                    if (Properties.Settings.Default.doTextScroll == true)
                    {
                        nextShowLabel.Text = nextShowLabel.Text + " ::: ";
                    }
                        
                }

            }
            catch
            {
                currentShowLabel.Text = "Now: ...";
                toolTip1.SetToolTip(currentShowLabel, "");
                nextShowLabel.Text = "Later: ...";
                toolTip1.SetToolTip(nextShowLabel, "");
            }
            
        }

        private void StudioTitleLabel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.showSelectorTitle = false;
            Properties.Settings.Default.Save();
            studioTitleLabel.Visible = false;
            label1.Visible = true;
        }

        private void Label4_DoubleClick_1(object sender, EventArgs e)
        {
            settingsBox sB = new settingsBox();
            sB.Show();
            
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Interval = 600000;

            if (Properties.Settings.Default.autoCheckUpdates == true)
            {
                try
                {
                    System.Net.WebRequest request = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/HTS126/MiniTimelord/master/CurrentVersion.txt");
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                    Globals.newestVersion = sr.ReadToEnd();
                    Globals.currentVersion = Application.ProductVersion;

                }
                catch
                {
                    Globals.currentVersion = Application.ProductVersion;
                    Globals.newestVersion = Application.ProductVersion;
                }

                if (Globals.newestVersion.Contains(Globals.currentVersion))
                {
                    label4.Text = "Settings";
                }
                else
                {
                    label4.Text = "Update Available";
                }
            }
            else
            {
                label4.Text = "Settings";
            }
        }

        private void SpeechTimer_Tick(object sender, EventArgs e)
        {
            RecTimeOut += 1;
            if(RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                speechTimer.Stop();
                try
                {
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
                var sound = new System.Media.SoundPlayer(Properties.Resources.done);
                sound.Play();
                Globals.isListening = false;
                RecTimeOut = 0;
            }
        }

        private void SpeechRestartTimer_Tick(object sender, EventArgs e)
        {
            if (Globals.isListening == false && Properties.Settings.Default.voiceActivationEnabled == true)
            {
                try
                {
                    _recognizer.RecognizeAsyncCancel();
                    startListening.RecognizeAsyncCancel();
                    Thread.Sleep(100);
                    _recognizer = new SpeechRecognitionEngine();
                    voice = new SpeechSynthesizer();
                    startListening = new SpeechRecognitionEngine();
                    _recognizer.SetInputToDefaultAudioDevice();
                    _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Play Online Feed", "Play A M Feed", "Play News Feed", "Play O B Feed", "Play Studio Red Feed", "Play Studio Blue Feed", "Play Web Studio Feed", "Play Jukebox Feed", "Stop Playing", "Stop"))));
                    _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
                    _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
                    startListening.SetInputToDefaultAudioDevice();
                    startListening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Okay Time Lord"))));
                    startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startListening_SpeechRecognized);
                    Thread.Sleep(100);
                    startListening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {

                }
            }
        }
    }
}
