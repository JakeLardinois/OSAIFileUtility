namespace OSAIFileUtility
{
    partial class frm8600Emulator
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
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
            this.cmdEmulateFileUpload = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdEmulateDir = new System.Windows.Forms.Button();
            this.cmdEmulateDelete = new System.Windows.Forms.Button();
            this.cmdEmulateFileDownload = new System.Windows.Forms.Button();
            this.btnGetFilePath = new System.Windows.Forms.Button();
            this.ofdPapFiles = new System.Windows.Forms.OpenFileDialog();
            this.cmdEmulateReset = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rtbDisplay);
            this.GroupBox1.Location = new System.Drawing.Point(7, 29);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(556, 260);
            this.GroupBox1.TabIndex = 21;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Serial Port Communication";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Location = new System.Drawing.Point(7, 19);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(543, 234);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(581, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 23);
            this.cmdClose.TabIndex = 19;
            this.cmdClose.Text = "Close Port";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(581, 256);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(100, 23);
            this.cmdOpen.TabIndex = 20;
            this.cmdOpen.Text = "Open Port";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(585, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 221);
            this.groupBox2.TabIndex = 18;
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
            // cmdEmulateFileUpload
            // 
            this.cmdEmulateFileUpload.Location = new System.Drawing.Point(7, 295);
            this.cmdEmulateFileUpload.Name = "cmdEmulateFileUpload";
            this.cmdEmulateFileUpload.Size = new System.Drawing.Size(112, 36);
            this.cmdEmulateFileUpload.TabIndex = 22;
            this.cmdEmulateFileUpload.Text = "Emulate File Upload";
            this.cmdEmulateFileUpload.UseVisualStyleBackColor = true;
            this.cmdEmulateFileUpload.Click += new System.EventHandler(this.cmdEmulateFileUpload_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(114, 344);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(535, 20);
            this.txtFilePath.TabIndex = 24;
            this.txtFilePath.Text = "C:\\Documents and Settings\\administrator.WIRETECHFAB\\Desktop\\180.pap";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "File To Emulate For :";
            // 
            // cmdEmulateDir
            // 
            this.cmdEmulateDir.Location = new System.Drawing.Point(125, 295);
            this.cmdEmulateDir.Name = "cmdEmulateDir";
            this.cmdEmulateDir.Size = new System.Drawing.Size(112, 36);
            this.cmdEmulateDir.TabIndex = 22;
            this.cmdEmulateDir.Text = "Emulate DIR";
            this.cmdEmulateDir.UseVisualStyleBackColor = true;
            this.cmdEmulateDir.Click += new System.EventHandler(this.cmdEmulateDir_Click);
            // 
            // cmdEmulateDelete
            // 
            this.cmdEmulateDelete.Location = new System.Drawing.Point(243, 295);
            this.cmdEmulateDelete.Name = "cmdEmulateDelete";
            this.cmdEmulateDelete.Size = new System.Drawing.Size(112, 36);
            this.cmdEmulateDelete.TabIndex = 22;
            this.cmdEmulateDelete.Text = "Emulate Delete";
            this.cmdEmulateDelete.UseVisualStyleBackColor = true;
            this.cmdEmulateDelete.Click += new System.EventHandler(this.cmdEmulateDelete_Click);
            // 
            // cmdEmulateFileDownload
            // 
            this.cmdEmulateFileDownload.Location = new System.Drawing.Point(361, 295);
            this.cmdEmulateFileDownload.Name = "cmdEmulateFileDownload";
            this.cmdEmulateFileDownload.Size = new System.Drawing.Size(112, 36);
            this.cmdEmulateFileDownload.TabIndex = 22;
            this.cmdEmulateFileDownload.Text = "Emulate File Download";
            this.cmdEmulateFileDownload.UseVisualStyleBackColor = true;
            this.cmdEmulateFileDownload.Click += new System.EventHandler(this.cmdEmulateFileDownload_Click);
            // 
            // btnGetFilePath
            // 
            this.btnGetFilePath.Location = new System.Drawing.Point(646, 344);
            this.btnGetFilePath.Name = "btnGetFilePath";
            this.btnGetFilePath.Size = new System.Drawing.Size(35, 20);
            this.btnGetFilePath.TabIndex = 29;
            this.btnGetFilePath.Text = "...";
            this.btnGetFilePath.UseVisualStyleBackColor = true;
            this.btnGetFilePath.Click += new System.EventHandler(this.btnGetFilePath_Click);
            // 
            // ofdPapFiles
            // 
            this.ofdPapFiles.Filter = "PAP Files|*.pap|All Files|*.*";
            // 
            // cmdEmulateReset
            // 
            this.cmdEmulateReset.Location = new System.Drawing.Point(479, 295);
            this.cmdEmulateReset.Name = "cmdEmulateReset";
            this.cmdEmulateReset.Size = new System.Drawing.Size(96, 36);
            this.cmdEmulateReset.TabIndex = 22;
            this.cmdEmulateReset.Text = "Emulate Reset";
            this.cmdEmulateReset.UseVisualStyleBackColor = true;
            this.cmdEmulateReset.Click += new System.EventHandler(this.cmdEmulateReset_Click);
            // 
            // frm8600Emulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 376);
            this.Controls.Add(this.btnGetFilePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.cmdEmulateDelete);
            this.Controls.Add(this.cmdEmulateDir);
            this.Controls.Add(this.cmdEmulateFileDownload);
            this.Controls.Add(this.cmdEmulateReset);
            this.Controls.Add(this.cmdEmulateFileUpload);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.groupBox2);
            this.Name = "frm8600Emulator";
            this.Text = "frm8600Emulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm8600Emulator_FormClosing);
            this.Load += new System.EventHandler(this.frm8600Emulator_Load);
            this.GroupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOpen;
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
        private System.Windows.Forms.Button cmdEmulateFileUpload;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdEmulateDir;
        private System.Windows.Forms.Button cmdEmulateDelete;
        private System.Windows.Forms.Button cmdEmulateFileDownload;
        private System.Windows.Forms.Button btnGetFilePath;
        private System.Windows.Forms.OpenFileDialog ofdPapFiles;
        private System.Windows.Forms.Button cmdEmulateReset;
    }
}