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
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic.PowerPacks;

namespace MiniTimelord
{
    public partial class settingsBox : Form
    {
        public settingsBox()
        {
            InitializeComponent();
        }

        void getSettings()
        {
            scrollCheck.Checked = Properties.Settings.Default.doTextScroll;
            studioTitleCheck.Checked = Properties.Settings.Default.showSelectorTitle;
            newsCheck.Checked = Properties.Settings.Default.doNews;
            jukeboxAlertCheck.Checked = Properties.Settings.Default.alertJukebox;
            deadAirAlertCheck.Checked = Properties.Settings.Default.alertDeadAir;
            checkUpdateCheck.Checked = Properties.Settings.Default.autoCheckUpdates;
            voiceCheck.Checked = Properties.Settings.Default.voiceActivationEnabled;
        }

      
        public static class SBGlobals
        {
            public static string currentVersion = "";
            public static string newestVersion = "";
        }

        void checkUpdates()
        {
            try
            {
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/HTS126/MiniTimelord/master/CurrentVersion.txt");
                System.Net.WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                SBGlobals.newestVersion = sr.ReadToEnd();
                SBGlobals.currentVersion = Application.ProductVersion;
                
            }
            catch
            {
                SBGlobals.currentVersion = Application.ProductVersion;
                SBGlobals.newestVersion = Application.ProductVersion;
            }
            
        }



        private void SettingsBox_Shown(object sender, EventArgs e)
        {
            getSettings();

            if(Properties.Settings.Default.autoCheckUpdates == true)
            {
                checkUpdates();
                if (SBGlobals.newestVersion.Contains(SBGlobals.currentVersion))
                {
                    updateLabel.Text = "Check for Updates";
                }
                else
                {
                    updateLabel.Text = "Update Available";
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult defaultConfirm = MessageBox.Show("Do you want to reset settings to default?", "Reset to Default?", MessageBoxButtons.YesNo);
            if (defaultConfirm == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                getSettings();
                Properties.Settings.Default.settingsUpgradeRequired = false;
                Properties.Settings.Default.Save();
                this.Close();
            }
            
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (voiceCheck.Checked == true && Properties.Settings.Default.voiceActivationEnabled == false)
            {
                DialogResult reloadReq = MessageBox.Show("To enable voice control, MiniTimelord must restart.\n \nPress 'Yes' to save settings and reload.\nPress 'No' to save all other settings, with voice control off.\nPress 'Cancel' to go back.", "Reload Required", MessageBoxButtons.YesNoCancel);
                if (reloadReq == DialogResult.Yes)
                {
                    Properties.Settings.Default.doNews = newsCheck.Checked;
                    Properties.Settings.Default.showSelectorTitle = studioTitleCheck.Checked;
                    Properties.Settings.Default.doTextScroll = scrollCheck.Checked;
                    Properties.Settings.Default.alertJukebox = jukeboxAlertCheck.Checked;
                    Properties.Settings.Default.alertDeadAir = deadAirAlertCheck.Checked;
                    Properties.Settings.Default.autoCheckUpdates = checkUpdateCheck.Checked;
                    Properties.Settings.Default.voiceActivationEnabled = voiceCheck.Checked;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
                else if (reloadReq == DialogResult.No)
                {
                    Properties.Settings.Default.doNews = newsCheck.Checked;
                    Properties.Settings.Default.showSelectorTitle = studioTitleCheck.Checked;
                    Properties.Settings.Default.doTextScroll = scrollCheck.Checked;
                    Properties.Settings.Default.alertJukebox = jukeboxAlertCheck.Checked;
                    Properties.Settings.Default.alertDeadAir = deadAirAlertCheck.Checked;
                    Properties.Settings.Default.autoCheckUpdates = checkUpdateCheck.Checked;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
            }
            else
            {
                Properties.Settings.Default.doNews = newsCheck.Checked;
                Properties.Settings.Default.showSelectorTitle = studioTitleCheck.Checked;
                Properties.Settings.Default.doTextScroll = scrollCheck.Checked;
                Properties.Settings.Default.alertJukebox = jukeboxAlertCheck.Checked;
                Properties.Settings.Default.alertDeadAir = deadAirAlertCheck.Checked;
                Properties.Settings.Default.autoCheckUpdates = checkUpdateCheck.Checked;
                Properties.Settings.Default.voiceActivationEnabled = voiceCheck.Checked;
                Properties.Settings.Default.Save();
                this.Close();
            }


            
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            if (updateLabel.Text == "Check for Updates")
            {
                checkUpdates();
                if (SBGlobals.newestVersion.Contains(SBGlobals.currentVersion))
                {
                    updateLabel.Text = "Check for Updates";
                    MessageBox.Show("No Update Available!");
                }
                else
                {
                    updateLabel.Text = "Update Available";
                }
            }
            else
            {
                DialogResult updateDialog = MessageBox.Show("An update is available!\n Click 'OK' to open GitHub Downloads.", "Update", MessageBoxButtons.OKCancel);
                if (updateDialog == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("https://github.com/HTS126/MiniTimelord/releases");
                    Application.Exit();

                }
            }


            
        }
    }
}
