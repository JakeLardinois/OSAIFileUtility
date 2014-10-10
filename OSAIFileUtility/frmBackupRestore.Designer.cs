namespace OSAIFileUtility
{
    partial class frmBackupRestore
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
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.cmdBackup = new System.Windows.Forms.Button();
            this.cmdGetMessagesbkpFilePath = new System.Windows.Forms.Button();
            this.txtMessageBkpFilePath = new System.Windows.Forms.TextBox();
            this.cmdGetUM2bkpFilePath = new System.Windows.Forms.Button();
            this.txtUM2BkpFilePath = new System.Windows.Forms.TextBox();
            this.cmdGetUM1BkpFilePath = new System.Windows.Forms.Button();
            this.txtUM1BkpFilePath = new System.Windows.Forms.TextBox();
            this.cmdGetCharBkpFilePath = new System.Windows.Forms.Button();
            this.txtCharBkpFilePath = new System.Windows.Forms.TextBox();
            this.chkBkpMessages = new System.Windows.Forms.CheckBox();
            this.chkBkpUserMemory2 = new System.Windows.Forms.CheckBox();
            this.chkBkpUserMemory1 = new System.Windows.Forms.CheckBox();
            this.chkBkpCharacterization = new System.Windows.Forms.CheckBox();
            this.grpRestore = new System.Windows.Forms.GroupBox();
            this.cmdRestore = new System.Windows.Forms.Button();
            this.chkRestoreMessages = new System.Windows.Forms.CheckBox();
            this.chkRestoreUserMemory2 = new System.Windows.Forms.CheckBox();
            this.chkRestoreUserMemory1 = new System.Windows.Forms.CheckBox();
            this.chkRestoreCharacterization = new System.Windows.Forms.CheckBox();
            this.cmdGetMessagesRestoreFilePath = new System.Windows.Forms.Button();
            this.txtMessageRestoreFilePath = new System.Windows.Forms.TextBox();
            this.cmdGetUM2RestoreFilePath = new System.Windows.Forms.Button();
            this.txtUM2RestoreFilePath = new System.Windows.Forms.TextBox();
            this.cmdGetUM1RestoreFilePath = new System.Windows.Forms.Button();
            this.txtUM1RestoreFilePath = new System.Windows.Forms.TextBox();
            this.cmdGetCharRestoreFilePath = new System.Windows.Forms.Button();
            this.txtCharRestoreFilePath = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.sfdChaFile = new System.Windows.Forms.SaveFileDialog();
            this.sfdUM1File = new System.Windows.Forms.SaveFileDialog();
            this.sfdUM2File = new System.Windows.Forms.SaveFileDialog();
            this.sfdMessageFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdChaFile = new System.Windows.Forms.OpenFileDialog();
            this.ofdUM1File = new System.Windows.Forms.OpenFileDialog();
            this.ofdUM2File = new System.Windows.Forms.OpenFileDialog();
            this.ofdMessageFile = new System.Windows.Forms.OpenFileDialog();
            this.cmdReset = new System.Windows.Forms.Button();
            this.grpBackup.SuspendLayout();
            this.grpRestore.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.cmdBackup);
            this.grpBackup.Controls.Add(this.cmdGetMessagesbkpFilePath);
            this.grpBackup.Controls.Add(this.txtMessageBkpFilePath);
            this.grpBackup.Controls.Add(this.cmdGetUM2bkpFilePath);
            this.grpBackup.Controls.Add(this.txtUM2BkpFilePath);
            this.grpBackup.Controls.Add(this.cmdGetUM1BkpFilePath);
            this.grpBackup.Controls.Add(this.txtUM1BkpFilePath);
            this.grpBackup.Controls.Add(this.cmdGetCharBkpFilePath);
            this.grpBackup.Controls.Add(this.txtCharBkpFilePath);
            this.grpBackup.Controls.Add(this.chkBkpMessages);
            this.grpBackup.Controls.Add(this.chkBkpUserMemory2);
            this.grpBackup.Controls.Add(this.chkBkpUserMemory1);
            this.grpBackup.Controls.Add(this.chkBkpCharacterization);
            this.grpBackup.Location = new System.Drawing.Point(8, 148);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(562, 145);
            this.grpBackup.TabIndex = 0;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Backup";
            // 
            // cmdBackup
            // 
            this.cmdBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBackup.Location = new System.Drawing.Point(450, 121);
            this.cmdBackup.Name = "cmdBackup";
            this.cmdBackup.Size = new System.Drawing.Size(106, 23);
            this.cmdBackup.TabIndex = 37;
            this.cmdBackup.Text = "Backup";
            this.cmdBackup.UseVisualStyleBackColor = true;
            this.cmdBackup.Click += new System.EventHandler(this.cmdBackup_Click);
            // 
            // cmdGetMessagesbkpFilePath
            // 
            this.cmdGetMessagesbkpFilePath.Enabled = false;
            this.cmdGetMessagesbkpFilePath.Location = new System.Drawing.Point(521, 97);
            this.cmdGetMessagesbkpFilePath.Name = "cmdGetMessagesbkpFilePath";
            this.cmdGetMessagesbkpFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetMessagesbkpFilePath.TabIndex = 36;
            this.cmdGetMessagesbkpFilePath.Text = "...";
            this.cmdGetMessagesbkpFilePath.UseVisualStyleBackColor = true;
            this.cmdGetMessagesbkpFilePath.Click += new System.EventHandler(this.cmdGetMessagesbkpFilePath_Click);
            // 
            // txtMessageBkpFilePath
            // 
            this.txtMessageBkpFilePath.Enabled = false;
            this.txtMessageBkpFilePath.Location = new System.Drawing.Point(110, 95);
            this.txtMessageBkpFilePath.Name = "txtMessageBkpFilePath";
            this.txtMessageBkpFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtMessageBkpFilePath.TabIndex = 35;
            this.txtMessageBkpFilePath.Text = "C:\\Users\\administrator\\Desktop\\MSG.MSG";
            // 
            // cmdGetUM2bkpFilePath
            // 
            this.cmdGetUM2bkpFilePath.Enabled = false;
            this.cmdGetUM2bkpFilePath.Location = new System.Drawing.Point(521, 71);
            this.cmdGetUM2bkpFilePath.Name = "cmdGetUM2bkpFilePath";
            this.cmdGetUM2bkpFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetUM2bkpFilePath.TabIndex = 34;
            this.cmdGetUM2bkpFilePath.Text = "...";
            this.cmdGetUM2bkpFilePath.UseVisualStyleBackColor = true;
            this.cmdGetUM2bkpFilePath.Click += new System.EventHandler(this.cmdGetUM2bkpFilePath_Click);
            // 
            // txtUM2BkpFilePath
            // 
            this.txtUM2BkpFilePath.Enabled = false;
            this.txtUM2BkpFilePath.Location = new System.Drawing.Point(110, 70);
            this.txtUM2BkpFilePath.Name = "txtUM2BkpFilePath";
            this.txtUM2BkpFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtUM2BkpFilePath.TabIndex = 33;
            this.txtUM2BkpFilePath.Text = "C:\\Users\\administrator\\Desktop\\UM2.UM2";
            // 
            // cmdGetUM1BkpFilePath
            // 
            this.cmdGetUM1BkpFilePath.Enabled = false;
            this.cmdGetUM1BkpFilePath.Location = new System.Drawing.Point(521, 45);
            this.cmdGetUM1BkpFilePath.Name = "cmdGetUM1BkpFilePath";
            this.cmdGetUM1BkpFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetUM1BkpFilePath.TabIndex = 32;
            this.cmdGetUM1BkpFilePath.Text = "...";
            this.cmdGetUM1BkpFilePath.UseVisualStyleBackColor = true;
            this.cmdGetUM1BkpFilePath.Click += new System.EventHandler(this.cmdGetUM1BkpFilePath_Click);
            // 
            // txtUM1BkpFilePath
            // 
            this.txtUM1BkpFilePath.Enabled = false;
            this.txtUM1BkpFilePath.Location = new System.Drawing.Point(110, 45);
            this.txtUM1BkpFilePath.Name = "txtUM1BkpFilePath";
            this.txtUM1BkpFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtUM1BkpFilePath.TabIndex = 31;
            this.txtUM1BkpFilePath.Text = "C:\\Users\\administrator\\Desktop\\UM1.UM1";
            // 
            // cmdGetCharBkpFilePath
            // 
            this.cmdGetCharBkpFilePath.Enabled = false;
            this.cmdGetCharBkpFilePath.Location = new System.Drawing.Point(521, 18);
            this.cmdGetCharBkpFilePath.Name = "cmdGetCharBkpFilePath";
            this.cmdGetCharBkpFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetCharBkpFilePath.TabIndex = 30;
            this.cmdGetCharBkpFilePath.Text = "...";
            this.cmdGetCharBkpFilePath.UseVisualStyleBackColor = true;
            this.cmdGetCharBkpFilePath.Click += new System.EventHandler(this.cmdGetCharBkpFilePath_Click);
            // 
            // txtCharBkpFilePath
            // 
            this.txtCharBkpFilePath.Enabled = false;
            this.txtCharBkpFilePath.Location = new System.Drawing.Point(110, 19);
            this.txtCharBkpFilePath.Name = "txtCharBkpFilePath";
            this.txtCharBkpFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtCharBkpFilePath.TabIndex = 29;
            this.txtCharBkpFilePath.Text = "C:\\Users\\administrator\\Desktop\\CHA.CHA";
            // 
            // chkBkpMessages
            // 
            this.chkBkpMessages.AutoSize = true;
            this.chkBkpMessages.Location = new System.Drawing.Point(6, 98);
            this.chkBkpMessages.Name = "chkBkpMessages";
            this.chkBkpMessages.Size = new System.Drawing.Size(74, 17);
            this.chkBkpMessages.TabIndex = 0;
            this.chkBkpMessages.Text = "Messages";
            this.chkBkpMessages.UseVisualStyleBackColor = true;
            this.chkBkpMessages.CheckedChanged += new System.EventHandler(this.chkBkpMessages_CheckedChanged);
            // 
            // chkBkpUserMemory2
            // 
            this.chkBkpUserMemory2.AutoSize = true;
            this.chkBkpUserMemory2.Location = new System.Drawing.Point(6, 73);
            this.chkBkpUserMemory2.Name = "chkBkpUserMemory2";
            this.chkBkpUserMemory2.Size = new System.Drawing.Size(97, 17);
            this.chkBkpUserMemory2.TabIndex = 0;
            this.chkBkpUserMemory2.Text = "User Memory 2";
            this.chkBkpUserMemory2.UseVisualStyleBackColor = true;
            this.chkBkpUserMemory2.CheckedChanged += new System.EventHandler(this.chkBkpUserMemory2_CheckedChanged);
            // 
            // chkBkpUserMemory1
            // 
            this.chkBkpUserMemory1.AutoSize = true;
            this.chkBkpUserMemory1.Location = new System.Drawing.Point(7, 48);
            this.chkBkpUserMemory1.Name = "chkBkpUserMemory1";
            this.chkBkpUserMemory1.Size = new System.Drawing.Size(97, 17);
            this.chkBkpUserMemory1.TabIndex = 0;
            this.chkBkpUserMemory1.Text = "User Memory 1";
            this.chkBkpUserMemory1.UseVisualStyleBackColor = true;
            this.chkBkpUserMemory1.CheckedChanged += new System.EventHandler(this.chkBkpUserMemory1_CheckedChanged);
            // 
            // chkBkpCharacterization
            // 
            this.chkBkpCharacterization.AutoSize = true;
            this.chkBkpCharacterization.Location = new System.Drawing.Point(7, 21);
            this.chkBkpCharacterization.Name = "chkBkpCharacterization";
            this.chkBkpCharacterization.Size = new System.Drawing.Size(102, 17);
            this.chkBkpCharacterization.TabIndex = 0;
            this.chkBkpCharacterization.Text = "Characterization";
            this.chkBkpCharacterization.UseVisualStyleBackColor = true;
            this.chkBkpCharacterization.CheckedChanged += new System.EventHandler(this.chkBkpCharacterization_CheckedChanged);
            // 
            // grpRestore
            // 
            this.grpRestore.Controls.Add(this.cmdRestore);
            this.grpRestore.Controls.Add(this.chkRestoreMessages);
            this.grpRestore.Controls.Add(this.chkRestoreUserMemory2);
            this.grpRestore.Controls.Add(this.chkRestoreUserMemory1);
            this.grpRestore.Controls.Add(this.chkRestoreCharacterization);
            this.grpRestore.Controls.Add(this.cmdGetMessagesRestoreFilePath);
            this.grpRestore.Controls.Add(this.txtMessageRestoreFilePath);
            this.grpRestore.Controls.Add(this.cmdGetUM2RestoreFilePath);
            this.grpRestore.Controls.Add(this.txtUM2RestoreFilePath);
            this.grpRestore.Controls.Add(this.cmdGetUM1RestoreFilePath);
            this.grpRestore.Controls.Add(this.txtUM1RestoreFilePath);
            this.grpRestore.Controls.Add(this.cmdGetCharRestoreFilePath);
            this.grpRestore.Controls.Add(this.txtCharRestoreFilePath);
            this.grpRestore.Location = new System.Drawing.Point(8, 299);
            this.grpRestore.Name = "grpRestore";
            this.grpRestore.Size = new System.Drawing.Size(562, 151);
            this.grpRestore.TabIndex = 0;
            this.grpRestore.TabStop = false;
            this.grpRestore.Text = "Restore";
            // 
            // cmdRestore
            // 
            this.cmdRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRestore.Location = new System.Drawing.Point(450, 122);
            this.cmdRestore.Name = "cmdRestore";
            this.cmdRestore.Size = new System.Drawing.Size(106, 23);
            this.cmdRestore.TabIndex = 37;
            this.cmdRestore.Text = "Restore";
            this.cmdRestore.UseVisualStyleBackColor = true;
            this.cmdRestore.Click += new System.EventHandler(this.cmdRestore_Click);
            // 
            // chkRestoreMessages
            // 
            this.chkRestoreMessages.AutoSize = true;
            this.chkRestoreMessages.Location = new System.Drawing.Point(6, 99);
            this.chkRestoreMessages.Name = "chkRestoreMessages";
            this.chkRestoreMessages.Size = new System.Drawing.Size(74, 17);
            this.chkRestoreMessages.TabIndex = 39;
            this.chkRestoreMessages.Text = "Messages";
            this.chkRestoreMessages.UseVisualStyleBackColor = true;
            this.chkRestoreMessages.CheckedChanged += new System.EventHandler(this.chkRestoreMessages_CheckedChanged);
            // 
            // chkRestoreUserMemory2
            // 
            this.chkRestoreUserMemory2.AutoSize = true;
            this.chkRestoreUserMemory2.Location = new System.Drawing.Point(6, 73);
            this.chkRestoreUserMemory2.Name = "chkRestoreUserMemory2";
            this.chkRestoreUserMemory2.Size = new System.Drawing.Size(97, 17);
            this.chkRestoreUserMemory2.TabIndex = 40;
            this.chkRestoreUserMemory2.Text = "User Memory 2";
            this.chkRestoreUserMemory2.UseVisualStyleBackColor = true;
            this.chkRestoreUserMemory2.CheckedChanged += new System.EventHandler(this.chkRestoreUserMemory2_CheckedChanged);
            // 
            // chkRestoreUserMemory1
            // 
            this.chkRestoreUserMemory1.AutoSize = true;
            this.chkRestoreUserMemory1.Location = new System.Drawing.Point(6, 47);
            this.chkRestoreUserMemory1.Name = "chkRestoreUserMemory1";
            this.chkRestoreUserMemory1.Size = new System.Drawing.Size(97, 17);
            this.chkRestoreUserMemory1.TabIndex = 37;
            this.chkRestoreUserMemory1.Text = "User Memory 1";
            this.chkRestoreUserMemory1.UseVisualStyleBackColor = true;
            this.chkRestoreUserMemory1.CheckedChanged += new System.EventHandler(this.chkRestoreUserMemory1_CheckedChanged);
            // 
            // chkRestoreCharacterization
            // 
            this.chkRestoreCharacterization.AutoSize = true;
            this.chkRestoreCharacterization.Location = new System.Drawing.Point(7, 21);
            this.chkRestoreCharacterization.Name = "chkRestoreCharacterization";
            this.chkRestoreCharacterization.Size = new System.Drawing.Size(102, 17);
            this.chkRestoreCharacterization.TabIndex = 38;
            this.chkRestoreCharacterization.Text = "Characterization";
            this.chkRestoreCharacterization.UseVisualStyleBackColor = true;
            this.chkRestoreCharacterization.CheckedChanged += new System.EventHandler(this.chkRestoreCharacterization_CheckedChanged);
            // 
            // cmdGetMessagesRestoreFilePath
            // 
            this.cmdGetMessagesRestoreFilePath.Enabled = false;
            this.cmdGetMessagesRestoreFilePath.Location = new System.Drawing.Point(521, 96);
            this.cmdGetMessagesRestoreFilePath.Name = "cmdGetMessagesRestoreFilePath";
            this.cmdGetMessagesRestoreFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetMessagesRestoreFilePath.TabIndex = 36;
            this.cmdGetMessagesRestoreFilePath.Text = "...";
            this.cmdGetMessagesRestoreFilePath.UseVisualStyleBackColor = true;
            this.cmdGetMessagesRestoreFilePath.Click += new System.EventHandler(this.cmdGetMessagesRestoreFilePath_Click);
            // 
            // txtMessageRestoreFilePath
            // 
            this.txtMessageRestoreFilePath.Enabled = false;
            this.txtMessageRestoreFilePath.Location = new System.Drawing.Point(110, 96);
            this.txtMessageRestoreFilePath.Name = "txtMessageRestoreFilePath";
            this.txtMessageRestoreFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtMessageRestoreFilePath.TabIndex = 35;
            this.txtMessageRestoreFilePath.Text = "C:\\Users\\administrator\\Desktop\\MSG.MSG";
            // 
            // cmdGetUM2RestoreFilePath
            // 
            this.cmdGetUM2RestoreFilePath.Enabled = false;
            this.cmdGetUM2RestoreFilePath.Location = new System.Drawing.Point(521, 70);
            this.cmdGetUM2RestoreFilePath.Name = "cmdGetUM2RestoreFilePath";
            this.cmdGetUM2RestoreFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetUM2RestoreFilePath.TabIndex = 34;
            this.cmdGetUM2RestoreFilePath.Text = "...";
            this.cmdGetUM2RestoreFilePath.UseVisualStyleBackColor = true;
            this.cmdGetUM2RestoreFilePath.Click += new System.EventHandler(this.cmdGetUM2RestoreFilePath_Click);
            // 
            // txtUM2RestoreFilePath
            // 
            this.txtUM2RestoreFilePath.Enabled = false;
            this.txtUM2RestoreFilePath.Location = new System.Drawing.Point(110, 70);
            this.txtUM2RestoreFilePath.Name = "txtUM2RestoreFilePath";
            this.txtUM2RestoreFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtUM2RestoreFilePath.TabIndex = 33;
            this.txtUM2RestoreFilePath.Text = "C:\\Users\\administrator\\Desktop\\UM2.UM2";
            // 
            // cmdGetUM1RestoreFilePath
            // 
            this.cmdGetUM1RestoreFilePath.Enabled = false;
            this.cmdGetUM1RestoreFilePath.Location = new System.Drawing.Point(521, 44);
            this.cmdGetUM1RestoreFilePath.Name = "cmdGetUM1RestoreFilePath";
            this.cmdGetUM1RestoreFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetUM1RestoreFilePath.TabIndex = 32;
            this.cmdGetUM1RestoreFilePath.Text = "...";
            this.cmdGetUM1RestoreFilePath.UseVisualStyleBackColor = true;
            this.cmdGetUM1RestoreFilePath.Click += new System.EventHandler(this.cmdGetUM1RestoreFilePath_Click);
            // 
            // txtUM1RestoreFilePath
            // 
            this.txtUM1RestoreFilePath.Enabled = false;
            this.txtUM1RestoreFilePath.Location = new System.Drawing.Point(110, 43);
            this.txtUM1RestoreFilePath.Name = "txtUM1RestoreFilePath";
            this.txtUM1RestoreFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtUM1RestoreFilePath.TabIndex = 31;
            this.txtUM1RestoreFilePath.Text = "C:\\Users\\administrator\\Desktop\\UM1.UM1";
            // 
            // cmdGetCharRestoreFilePath
            // 
            this.cmdGetCharRestoreFilePath.Enabled = false;
            this.cmdGetCharRestoreFilePath.Location = new System.Drawing.Point(521, 18);
            this.cmdGetCharRestoreFilePath.Name = "cmdGetCharRestoreFilePath";
            this.cmdGetCharRestoreFilePath.Size = new System.Drawing.Size(35, 20);
            this.cmdGetCharRestoreFilePath.TabIndex = 30;
            this.cmdGetCharRestoreFilePath.Text = "...";
            this.cmdGetCharRestoreFilePath.UseVisualStyleBackColor = true;
            this.cmdGetCharRestoreFilePath.Click += new System.EventHandler(this.cmdGetCharRestoreFilePath_Click);
            // 
            // txtCharRestoreFilePath
            // 
            this.txtCharRestoreFilePath.Enabled = false;
            this.txtCharRestoreFilePath.Location = new System.Drawing.Point(110, 19);
            this.txtCharRestoreFilePath.Name = "txtCharRestoreFilePath";
            this.txtCharRestoreFilePath.Size = new System.Drawing.Size(407, 20);
            this.txtCharRestoreFilePath.TabIndex = 29;
            this.txtCharRestoreFilePath.Text = "C:\\Users\\administrator\\Desktop\\CHA.CHA";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(576, 288);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 23);
            this.cmdClose.TabIndex = 17;
            this.cmdClose.Text = "Close Port";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpen.Location = new System.Drawing.Point(576, 259);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(100, 23);
            this.cmdOpen.TabIndex = 18;
            this.cmdOpen.Text = "Open Port";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboData);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cboStop);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboParity);
            this.groupBox3.Controls.Add(this.Label1);
            this.groupBox3.Controls.Add(this.cboBaud);
            this.groupBox3.Controls.Add(this.cboPort);
            this.groupBox3.Location = new System.Drawing.Point(580, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(96, 221);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
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
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rtbDisplay);
            this.groupBox4.Location = new System.Drawing.Point(8, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(556, 131);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Serial Port Communication";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(7, 19);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(543, 103);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            // 
            // sfdChaFile
            // 
            this.sfdChaFile.Filter = "CHA Files|*.cha|All Files|*.*";
            // 
            // sfdUM1File
            // 
            this.sfdUM1File.Filter = "UM1 Files|*.um1|All Files|*.*";
            // 
            // sfdUM2File
            // 
            this.sfdUM2File.Filter = "UM2 Files|*.um2|All Files|*.*";
            // 
            // sfdMessageFile
            // 
            this.sfdMessageFile.Filter = "MSG Files|*.msg|All Files|*.*";
            // 
            // ofdChaFile
            // 
            this.ofdChaFile.Filter = "CHA Files|*.cha|All Files|*.*";
            // 
            // ofdUM1File
            // 
            this.ofdUM1File.Filter = "UM1 Files|*.um1|All Files|*.*";
            // 
            // ofdUM2File
            // 
            this.ofdUM2File.Filter = "UM2 Files|*.um2|All Files|*.*";
            // 
            // ofdMessageFile
            // 
            this.ofdMessageFile.Filter = "MSG Files|*.msg|All Files|*.*";
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(587, 339);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(78, 23);
            this.cmdReset.TabIndex = 30;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // frmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 462);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpRestore);
            this.Controls.Add(this.grpBackup);
            this.Name = "frmBackupRestore";
            this.ShowIcon = false;
            this.Text = "Backup & Restore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBackupRestore_FormClosing);
            this.Load += new System.EventHandler(this.frmBackupRestore_Load);
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.grpRestore.ResumeLayout(false);
            this.grpRestore.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.GroupBox grpRestore;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.CheckBox chkBkpCharacterization;
        private System.Windows.Forms.Button cmdGetMessagesbkpFilePath;
        private System.Windows.Forms.TextBox txtMessageBkpFilePath;
        private System.Windows.Forms.Button cmdGetUM2bkpFilePath;
        private System.Windows.Forms.TextBox txtUM2BkpFilePath;
        private System.Windows.Forms.Button cmdGetUM1BkpFilePath;
        private System.Windows.Forms.TextBox txtUM1BkpFilePath;
        private System.Windows.Forms.Button cmdGetCharBkpFilePath;
        private System.Windows.Forms.TextBox txtCharBkpFilePath;
        private System.Windows.Forms.Button cmdGetMessagesRestoreFilePath;
        private System.Windows.Forms.TextBox txtMessageRestoreFilePath;
        private System.Windows.Forms.Button cmdGetUM2RestoreFilePath;
        private System.Windows.Forms.TextBox txtUM2RestoreFilePath;
        private System.Windows.Forms.Button cmdGetUM1RestoreFilePath;
        private System.Windows.Forms.TextBox txtUM1RestoreFilePath;
        private System.Windows.Forms.Button cmdGetCharRestoreFilePath;
        private System.Windows.Forms.TextBox txtCharRestoreFilePath;
        private System.Windows.Forms.CheckBox chkBkpMessages;
        private System.Windows.Forms.CheckBox chkBkpUserMemory2;
        private System.Windows.Forms.CheckBox chkBkpUserMemory1;
        private System.Windows.Forms.CheckBox chkRestoreMessages;
        private System.Windows.Forms.CheckBox chkRestoreUserMemory2;
        private System.Windows.Forms.CheckBox chkRestoreUserMemory1;
        private System.Windows.Forms.CheckBox chkRestoreCharacterization;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.SaveFileDialog sfdChaFile;
        private System.Windows.Forms.SaveFileDialog sfdUM1File;
        private System.Windows.Forms.SaveFileDialog sfdUM2File;
        private System.Windows.Forms.SaveFileDialog sfdMessageFile;
        private System.Windows.Forms.OpenFileDialog ofdChaFile;
        private System.Windows.Forms.OpenFileDialog ofdUM1File;
        private System.Windows.Forms.OpenFileDialog ofdUM2File;
        private System.Windows.Forms.OpenFileDialog ofdMessageFile;
        private System.Windows.Forms.Button cmdBackup;
        private System.Windows.Forms.Button cmdRestore;
        private System.Windows.Forms.Button cmdReset;
    }
}