using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
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
                    string upToDateMsg = "You are on version " + Application.ProductVersion + "\n This is the latest version!";
                    MessageBox.Show(upToDateMsg);
                }
                else
                {
                    updateLabel.Text = "Update Available";
                }
            }
            else
            {
                string newUpdateString = "Latest Version: " + SBGlobals.newestVersion + " \nYou are currently on version " + Application.ProductVersion + "\n \nClick OK to update.";
                DialogResult updateDialog = MessageBox.Show(newUpdateString, "Update", MessageBoxButtons.OKCancel);
                if (updateDialog == DialogResult.OK)
                {
                    try
                    {
                        string downloadLink = "https://github.com/HTS126/MiniTimelord/raw/master/MiniTimelordSetup/Release/MiniTimelordSetup.msi";
                        WebClient downloader = new WebClient();
                        string downloadFolder = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
                        string savePath = downloadFolder + "\\MiniTimelordUpdater.msi";
                        downloader.DownloadFile(downloadLink, savePath);
                        System.Threading.Thread.Sleep(5000);
                        Process.Start(savePath);
                        Application.Exit();

                    }
                    catch
                    {
                        MessageBox.Show("There was an error updating.\n Please try again later...");
                    }

                }
            }


            
        }

    }
}
