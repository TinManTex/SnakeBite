﻿namespace SnakeBite
{
    partial class formLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLauncher));
            this.buttonStartGame = new System.Windows.Forms.Label();
            this.buttonMods = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.AutoSize = true;
            this.buttonStartGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonStartGame.Location = new System.Drawing.Point(66, 239);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(141, 32);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            this.buttonStartGame.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.buttonStartGame.MouseLeave += new System.EventHandler(this.OnMouseExit);
            // 
            // buttonMods
            // 
            this.buttonMods.AutoSize = true;
            this.buttonMods.BackColor = System.Drawing.Color.Transparent;
            this.buttonMods.Location = new System.Drawing.Point(66, 275);
            this.buttonMods.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.buttonMods.Name = "buttonMods";
            this.buttonMods.Size = new System.Drawing.Size(79, 32);
            this.buttonMods.TabIndex = 1;
            this.buttonMods.Text = "Mods";
            this.buttonMods.Click += new System.EventHandler(this.buttonMods_Click);
            this.buttonMods.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.buttonMods.MouseLeave += new System.EventHandler(this.OnMouseExit);
            // 
            // buttonSettings
            // 
            this.buttonSettings.AutoSize = true;
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.Location = new System.Drawing.Point(66, 311);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(107, 32);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            this.buttonSettings.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.buttonSettings.MouseLeave += new System.EventHandler(this.OnMouseExit);
            // 
            // buttonExit
            // 
            this.buttonExit.AutoSize = true;
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(66, 347);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(57, 32);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.OnMouseExit);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(682, 408);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelVersion.Size = new System.Drawing.Size(74, 15);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = "Version Info";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.labelVersion.TextChanged += new System.EventHandler(this.labelVersion_TextChanged);
            this.labelVersion.DoubleClick += new System.EventHandler(this.labelVersion_DoubleClick);
            // 
            // formLauncher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::SnakeBite.Properties.Resources.LAUNCHERBG;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonMods);
            this.Controls.Add(this.buttonStartGame);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "formLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnakeBite Launcher";
            this.Load += new System.EventHandler(this.formLauncher_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formLauncher_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label buttonStartGame;
        private System.Windows.Forms.Label buttonMods;
        private System.Windows.Forms.Label buttonSettings;
        private System.Windows.Forms.Label buttonExit;
        private System.Windows.Forms.Label labelVersion;
    }
}