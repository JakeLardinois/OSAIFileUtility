namespace OSAIFileUtility
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSAIFileUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortCommunicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToAsciiConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oSAIFileUtilityToolStripMenuItem,
            this.serialPortCommunicatorToolStripMenuItem,
            this.hexToAsciiConverterToolStripMenuItem,
            this.emulatorToolStripMenuItem,
            this.backupRestoreToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // oSAIFileUtilityToolStripMenuItem
            // 
            this.oSAIFileUtilityToolStripMenuItem.Name = "oSAIFileUtilityToolStripMenuItem";
            this.oSAIFileUtilityToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.oSAIFileUtilityToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.oSAIFileUtilityToolStripMenuItem.Text = "OSAI File Utility";
            this.oSAIFileUtilityToolStripMenuItem.Click += new System.EventHandler(this.oSAIFileUtilityToolStripMenuItem_Click);
            // 
            // serialPortCommunicatorToolStripMenuItem
            // 
            this.serialPortCommunicatorToolStripMenuItem.Name = "serialPortCommunicatorToolStripMenuItem";
            this.serialPortCommunicatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.serialPortCommunicatorToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.serialPortCommunicatorToolStripMenuItem.Text = "Serial Port Communicator";
            this.serialPortCommunicatorToolStripMenuItem.Visible = false;
            this.serialPortCommunicatorToolStripMenuItem.Click += new System.EventHandler(this.serialPortCommunicatorToolStripMenuItem_Click);
            // 
            // hexToAsciiConverterToolStripMenuItem
            // 
            this.hexToAsciiConverterToolStripMenuItem.Name = "hexToAsciiConverterToolStripMenuItem";
            this.hexToAsciiConverterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.hexToAsciiConverterToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.hexToAsciiConverterToolStripMenuItem.Text = "Hex To Ascii Converter";
            this.hexToAsciiConverterToolStripMenuItem.Visible = false;
            this.hexToAsciiConverterToolStripMenuItem.Click += new System.EventHandler(this.hexToAsciiConverterToolStripMenuItem_Click);
            // 
            // emulatorToolStripMenuItem
            // 
            this.emulatorToolStripMenuItem.Name = "emulatorToolStripMenuItem";
            this.emulatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.emulatorToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.emulatorToolStripMenuItem.Text = "8600 Emulator";
            this.emulatorToolStripMenuItem.Visible = false;
            this.emulatorToolStripMenuItem.Click += new System.EventHandler(this.emulatorToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.backupRestoreToolStripMenuItem.Text = "Backup/Restore";
            this.backupRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupRestoreToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 433);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "CNC Upload/Download Utility";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSAIFileUtilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortCommunicatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToAsciiConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
    }
}

