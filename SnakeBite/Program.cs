﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SnakeBite
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsManager manager = new SettingsManager(ModManager.GameDir);
            manager.DisableConflictCheck = false;
            if (Properties.Settings.Default.LastSBVersion == null || new Version(Properties.Settings.Default.LastSBVersion) < ModManager.GetSBVersion())
            {
                Properties.Settings.Default.Upgrade();
            }

            Properties.Settings.Default.LastSBVersion = ModManager.GetSBVersion().ToString();
            Properties.Settings.Default.Save();

            Debug.Clear();

            Debug.LogLine(String.Format(
                "SnakeBite {0}\n" +
                "{1}\n" + 
                "-------------------------",
                ModManager.GetSBVersion(),
                Environment.OSVersion.VersionString));

            // Delete old settings file
            if (File.Exists(ModManager.GameDir + "\\sbmods.xml"))
            {
                Debug.LogLine("Settings v0.7 or less detected, removing");
                File.Delete(ModManager.GameDir + "\\sbmods.xml");
                MessageBox.Show("Due to fundamental changes from version 0.8 onwards, your settings have been reset. Please re-verify or restore the game files and run the setup wizard before continuing.", "Version Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool showSetupWizard = false;

            if (!manager.SettingsExist() || !manager.ValidInstallPath)
            {
                showSetupWizard = true;
            }

            // Show wizard on first run, if folder is invalid or settings out of date
            while (showSetupWizard)
            {
                // show setup wizard
                Debug.LogLine("Showing setup wizard");
                SetupWizard.SetupWizard setupWizard = new SetupWizard.SetupWizard();
                var wizResult = setupWizard.ShowDialog();
                if (wizResult == DialogResult.Cancel) return;
                if (wizResult == DialogResult.OK) showSetupWizard = false;
            }



            string InitLog = String.Format(
                "MGS Install Folder: {0}\n" +
                "MGS Version: {1}\n" +
                "-------------------------",
                Properties.Settings.Default.InstallPath,
                ModManager.GetMGSVersion());

            Debug.LogLine(InitLog, Debug.LogLevel.Basic);



            // Process Command Line args
            // TODO: test all command line args

            // Uninstall SnakeBite
            if (args.Length == 1)
            {
                if (args[0] == "-completeuninstall")
                {
                    Debug.LogLine("Complete uninstall");
                    // Restore backup and remove settings
                    manager.DeleteSettings();
                    BackupManager.RestoreOriginals();
                    return;
                }
            }

            // Parse command line arguments
            bool doCmdLine = false;             // Process command line args?
            bool closeApp = false;              // Close app after?
            bool install = false;               // Install = true, uninstall = false
            bool ignoreConflicts = false;       // Bypass conflict check
            bool resetDatHash = false;          // Rehash dat file
            bool skipCleanup = true;            // Skip CleanupDatabase
            string installFile = String.Empty;
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    switch (arg.ToLower())
                    {
                        case "-i":
                            install = true;
                            break;

                        case "-u":
                            install = false;

                            break;

                        case "-c":
                            ignoreConflicts = true;
                            break;

                        case "-d":
                            resetDatHash = true;
                            break;

                        case "-x":
                            closeApp = true;
                            break;
                        case "-s":
                            skipCleanup = true;
                            break;

                        default:
                            installFile = arg;
                            doCmdLine = true;
                            break;
                    }
                }
            }

            // Update dat hash in settings
            if (resetDatHash)
            {
                Debug.LogLine("Resetting dat hash");
                manager.UpdateDatHash();
            }

            var checkDat = manager.ValidateDatHash();

            if (!checkDat)
            {
                MessageBox.Show("Game archive has been modified. The setup wizard will now run.", "Game data hash mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetupWizard.SetupWizard setupWizard = new SetupWizard.SetupWizard();
                setupWizard.ShowDialog();
            }

            if (!BackupManager.c7t7Exist())
            {
                MessageBox.Show("Important SnakeBite files, \"a_texture7.dat\" and/or \"a_chunk7.dat\", appear to be missing from the master directory. Please verify the integrity of the game through Steam.", "Important Data is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (doCmdLine)
            {
                Debug.LogLine("Doing cmd line args");
                formMods ModForm = new formMods();
                ModForm.Show();
                ModForm.Hide();
                if (install)
                {
                    // install
                    ModForm.ProcessInstallMod(installFile, skipCleanup); // install mod
                }
                else
                {
                    // uninstall
                    var mods = manager.GetInstalledMods();
                    ModEntry mod = mods.FirstOrDefault(entry => entry.Name == installFile); // select mod

                    if (mod != null)
                        ModForm.ProcessUninstallMod(mod); // uninstall mod
                }
                ModForm.Dispose();

                if (closeApp) return;
            }

            //Application.Run(new formMain());
            Application.Run(new formLauncher());
        }
    }
}