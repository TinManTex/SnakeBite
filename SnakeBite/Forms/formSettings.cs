﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SnakeBite
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }

        private void CheckBackupState()
        {
            bool backupExists = BackupManager.OriginalsExist();
            {
                buttonToggleMods.Enabled = backupExists;
                buttonRestoreOriginals.Enabled = backupExists;
            }
        }

        private void UpdateModToggle()
        {
            bool enabled = !BackupManager.ModsDisabled();
            buttonToggleMods.Text = enabled ? "Disable Mods" : "Enable Mods";
            buttonSetupWizard.Enabled = enabled;
        }

        private void buttonRestoreOriginals_Click(object sender, EventArgs e)
        {
            var restoreData = MessageBox.Show("Your original backup files will be restored, and any SnakeBite settings and mods will be completely removed.\n\nAre you sure you want to continue?", "SnakeBite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (restoreData == DialogResult.No) return;

            if (BackupManager.OriginalsExist())
            {
                BackupManager.RestoreOriginals();
                SettingsManager.DeleteSettings();
                Application.Exit();
            }
        }

        private void buttonToggleMods_Click(object sender, EventArgs e)
        {

            BackgroundWorker toggleWorker = new BackgroundWorker();

            if (BackupManager.ModsDisabled())
            {
                // re-enable mods
                toggleWorker.DoWork += (obj, var) => BackupManager.SwitchToMods();
            }
            else
            {
                // disable mods
                toggleWorker.DoWork += (obj, var) => BackupManager.SwitchToOriginal();
            }

            toggleWorker.RunWorkerAsync();
            while (toggleWorker.IsBusy)
            {
                Application.DoEvents();
            }

            UpdateModToggle();
        }

        private void buttonSetup(object sender, EventArgs e)
        {
            SetupWizard.SetupWizard setupWizard = new SetupWizard.SetupWizard();
            setupWizard.Tag = "closable";
            setupWizard.ShowDialog();
            CheckBackupState();
        }


        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.labelGithub.Text);
        }

        private void checkConflicts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkConflicts.Checked && SettingsManager.DisableConflictCheck == false)
            {
                MessageBox.Show("Enabling this option completely disables any warnings when installing mods, and may overwrite existing mod or game data.\n\n"+
                                "This may cause issues with some mods - or cause the game to hang, crash or worse - and it is recommended that you make a seperate backup before continuing.\n\n"+
                                "This option will only persist until you exit SnakeBite.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SettingsManager.DisableConflictCheck = checkConflicts.Checked;
        }

        private void buttonFindMGSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog findMGSV = new OpenFileDialog();
            findMGSV.Filter = "Metal Gear Solid V|MGSVTPP.exe";
            DialogResult findResult = findMGSV.ShowDialog();
            if (findResult != DialogResult.OK) return;

            string filePath = findMGSV.FileName.Substring(0, findMGSV.FileName.LastIndexOf("\\"));
            if (filePath != textInstallPath.Text)
            {
                textInstallPath.Text = filePath;
                Properties.Settings.Default.InstallPath = filePath;
                Properties.Settings.Default.Save();
                MessageBox.Show("SnakeBite will now restart.", "SnakeBite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("SnakeBite.exe");
                Application.Exit();
            }
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            // Set installation path textbox
            textInstallPath.Text = Properties.Settings.Default.InstallPath;
            checkConflicts.Checked = SettingsManager.DisableConflictCheck;
            checkBox1.Checked = Properties.Settings.Default.EnableSound;
            UpdateModToggle();
        }

        private void checkEnableSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableSound = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
