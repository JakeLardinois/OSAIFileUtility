namespace OSAIFileUtility
{
    partial class frmOSAIFileUtility
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboData = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.objProgressBar = new System.Windows.Forms.ProgressBar();
            this.cmdGetDirectoryPath = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.cmdRecieveFile = new System.Windows.Forms.Button();
            this.cmdDeleteFile = new System.Windows.Forms.Button();
            this.dgvProgramFileList = new System.Windows.Forms.DataGridView();
            this.cmdGetFilePath = new System.Windows.Forms.Button();
            this.cmdSendFile = new System.Windows.Forms.Button();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.cmuConsole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdListDirectory = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.ofdPapFiles = new System.Windows.Forms.OpenFileDialog();
            this.sfdPapFiles = new System.Windows.Forms.SaveFileDialog();
            this.fbdSaveDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.findStrip1 = new OSAIFileUtility.FindStrip();
            this.groupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramFileList)).BeginInit();
            this.cmuConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboData);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboStop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboParity);
            this.groupBox2.Controls.Add(this.Label1);
            this.groupBox2.Controls.Add(this.cboBaud);
            this.groupBox2.Controls.Add(this.cboPort);
            this.groupBox2.Location = new System.Drawing.Point(580, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 221);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data Bits";
            // 
            // cboData
            // 
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(9, 195);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(76, 21);
            this.cboData.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Stop Bits";
            // 
            // cboStop
            // 
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Location = new System.Drawing.Point(9, 155);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(76, 21);
            this.cboStop.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Baud Rate";
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(9, 114);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(76, 21);
            this.cboParity.TabIndex = 12;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Port";
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cboBaud.Location = new System.Drawing.Point(9, 74);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(76, 21);
            this.cboBaud.TabIndex = 11;
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(9, 34);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(76, 21);
            this.cboPort.TabIndex = 10;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(576, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 23);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "Close Port";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpen.Location = new System.Drawing.Point(576, 260);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(100, 23);
            this.cmdOpen.TabIndex = 15;
            this.cmdOpen.Text = "Open Port";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.findStrip1);
            this.GroupBox1.Controls.Add(this.objProgressBar);
            this.GroupBox1.Controls.Add(this.cmdGetDirectoryPath);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.txtDirectoryPath);
            this.GroupBox1.Controls.Add(this.cmdRecieveFile);
            this.GroupBox1.Controls.Add(this.cmdDeleteFile);
            this.GroupBox1.Controls.Add(this.dgvProgramFileList);
            this.GroupBox1.Controls.Add(this.cmdGetFilePath);
            this.GroupBox1.Controls.Add(this.cmdSendFile);
            this.GroupBox1.Controls.Add(this.rtbDisplay);
            this.GroupBox1.Controls.Add(this.cmdListDirectory);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.txtFilePath);
            this.GroupBox1.Location = new System.Drawing.Point(2, 23);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(556, 336);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Serial Port Communication";
            // 
            // objProgressBar
            // 
            this.objProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objProgressBar.Location = new System.Drawing.Point(161, 115);
            this.objProgressBar.Name = "objProgressBar";
            this.objProgressBar.Size = new System.Drawing.Size(307, 23);
            this.objProgressBar.Step = 1;
            this.objProgressBar.TabIndex = 32;
            // 
            // cmdGetDirectoryPath
            // 
            this.cmdGetDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetDirectoryPath.Location = new System.Drawing.Point(433, 277);
            this.cmdGetDirectoryPath.Name = "cmdGetDirectoryPath";
            this.cmdGetDirectoryPath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetDirectoryPath.TabIndex = 31;
            this.cmdGetDirectoryPath.Text = "...";
            this.cmdGetDirectoryPath.UseVisualStyleBackColor = true;
            this.cmdGetDirectoryPath.Click += new System.EventHandler(this.cmdGetDirectoryPath_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Save Directory :";
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectoryPath.Location = new System.Drawing.Point(98, 278);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(338, 20);
            this.txtDirectoryPath.TabIndex = 29;
            this.txtDirectoryPath.Text = "C:\\Users\\administrator\\Desktop";
            // 
            // cmdRecieveFile
            // 
            this.cmdRecieveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRecieveFile.Location = new System.Drawing.Point(472, 275);
            this.cmdRecieveFile.Name = "cmdRecieveFile";
            this.cmdRecieveFile.Size = new System.Drawing.Size(78, 23);
            this.cmdRecieveFile.TabIndex = 6;
            this.cmdRecieveFile.Text = "Download";
            this.cmdRecieveFile.UseVisualStyleBackColor = true;
            this.cmdRecieveFile.Click += new System.EventHandler(this.cmdRecieveFile_Click);
            // 
            // cmdDeleteFile
            // 
            this.cmdDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteFile.Location = new System.Drawing.Point(472, 153);
            this.cmdDeleteFile.Name = "cmdDeleteFile";
            this.cmdDeleteFile.Size = new System.Drawing.Size(78, 23);
            this.cmdDeleteFile.TabIndex = 5;
            this.cmdDeleteFile.Text = "Delete";
            this.cmdDeleteFile.UseVisualStyleBackColor = true;
            this.cmdDeleteFile.Click += new System.EventHandler(this.cmdDeleteFile_Click);
            // 
            // dgvProgramFileList
            // 
            this.dgvProgramFileList.AllowUserToAddRows = false;
            this.dgvProgramFileList.AllowUserToDeleteRows = false;
            this.dgvProgramFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProgramFileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgramFileList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProgramFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProgramFileList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProgramFileList.Location = new System.Drawing.Point(10, 144);
            this.dgvProgramFileList.Name = "dgvProgramFileList";
            this.dgvProgramFileList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgramFileList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProgramFileList.Size = new System.Drawing.Size(458, 128);
            this.dgvProgramFileList.TabIndex = 4;
            // 
            // cmdGetFilePath
            // 
            this.cmdGetFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetFilePath.Location = new System.Drawing.Point(433, 302);
            this.cmdGetFilePath.Name = "cmdGetFilePath";
            this.cmdGetFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetFilePath.TabIndex = 28;
            this.cmdGetFilePath.Text = "...";
            this.cmdGetFilePath.UseVisualStyleBackColor = true;
            this.cmdGetFilePath.Click += new System.EventHandler(this.cmdGetFilePath_Click);
            // 
            // cmdSendFile
            // 
            this.cmdSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSendFile.Location = new System.Drawing.Point(472, 300);
            this.cmdSendFile.Name = "cmdSendFile";
            this.cmdSendFile.Size = new System.Drawing.Size(78, 23);
            this.cmdSendFile.TabIndex = 17;
            this.cmdSendFile.Text = "Upload";
            this.cmdSendFile.UseVisualStyleBackColor = true;
            this.cmdSendFile.Click += new System.EventHandler(this.cmdSendFile_Click);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.ContextMenuStrip = this.cmuConsole;
            this.rtbDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbDisplay.Location = new System.Drawing.Point(10, 48);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(540, 58);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            // 
            // cmuConsole
            // 
            this.cmuConsole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearScreenToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.cmuConsole.Name = "cmuConsole";
            this.cmuConsole.Size = new System.Drawing.Size(140, 48);
            // 
            // clearScreenToolStripMenuItem
            // 
            this.clearScreenToolStripMenuItem.Name = "clearScreenToolStripMenuItem";
            this.clearScreenToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.clearScreenToolStripMenuItem.Text = "Clear Screen";
            this.clearScreenToolStripMenuItem.Click += new System.EventHandler(this.clearScreenToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // cmdListDirectory
            // 
            this.cmdListDirectory.Location = new System.Drawing.Point(12, 112);
            this.cmdListDirectory.Name = "cmdListDirectory";
            this.cmdListDirectory.Size = new System.Drawing.Size(78, 23);
            this.cmdListDirectory.TabIndex = 15;
            this.cmdListDirectory.Text = "List Directory";
            this.cmdListDirectory.UseVisualStyleBackColor = true;
            this.cmdListDirectory.Click += new System.EventHandler(this.cmdListDirectory_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "File to Send :";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(98, 303);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(338, 20);
            this.txtFilePath.TabIndex = 26;
            this.txtFilePath.Text = "C:\\Users\\administrator\\Desktop\\180.pap";
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(576, 336);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(100, 23);
            this.cmdReset.TabIndex = 29;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // ofdPapFiles
            // 
            this.ofdPapFiles.Filter = "PAP Files|*.pap|All Files|*.*";
            // 
            // sfdPapFiles
            // 
            this.sfdPapFiles.Filter = "PAP Files|*.pap|All Files|*.*";
            // 
            // findStrip1
            // 
            this.findStrip1.BindingSource = null;
            this.findStrip1.Location = new System.Drawing.Point(3, 16);
            this.findStrip1.Name = "findStrip1";
            this.findStrip1.Size = new System.Drawing.Size(550, 25);
            this.findStrip1.TabIndex = 33;
            this.findStrip1.Text = "findStrip1";
            this.findStrip1.ItemFound += new OSAIFileUtility.ItemFoundEventHandler(this.findStrip1_ItemFound);
            // 
            // frmOSAIFileUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 418);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmOSAIFileUtility";
            this.ShowIcon = false;
            this.Text = "File Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOSAIFileUtility_FormClosing);
            this.Load += new System.EventHandler(this.frmOSAIFileUtility_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramFileList)).EndInit();
            this.cmuConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button cmdSendFile;
        private System.Windows.Forms.ContextMenuStrip cmuConsole;
        private System.Windows.Forms.ToolStripMenuItem clearScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog ofdPapFiles;
        private System.Windows.Forms.Button cmdGetFilePath;
        private System.Windows.Forms.Button cmdListDirectory;
        private System.Windows.Forms.DataGridView dgvProgramFileList;
        private System.Windows.Forms.Button cmdRecieveFile;
        private System.Windows.Forms.Button cmdDeleteFile;
        private System.Windows.Forms.SaveFileDialog sfdPapFiles;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdGetDirectoryPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.FolderBrowserDialog fbdSaveDirectory;
        private System.Windows.Forms.ProgressBar objProgressBar;
        public static System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FindStrip findStrip1;
    }
}