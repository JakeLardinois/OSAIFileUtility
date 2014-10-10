namespace OSAIFileUtility
{
    partial class frmHexToAscii
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelectedHex = new System.Windows.Forms.TextBox();
            this.lblSelectedAsciiLine = new System.Windows.Forms.Label();
            this.lblSelectedHexLine = new System.Windows.Forms.Label();
            this.lblAsciiLineCount = new System.Windows.Forms.Label();
            this.lblHexLineCount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmuAscii = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToHexLineEquivalentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStringsToRemove = new System.Windows.Forms.TextBox();
            this.cmuHex = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToAsciiLineEquivalentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedTextToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chkEnableEdit = new System.Windows.Forms.CheckBox();
            this.txtHexDelimiter = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHex = new System.Windows.Forms.RichTextBox();
            this.txtAscii = new System.Windows.Forms.RichTextBox();
            this.cmuAscii.SuspendLayout();
            this.cmuHex.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Selected Hex Ascii Equivalent :";
            // 
            // txtSelectedHex
            // 
            this.txtSelectedHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedHex.Location = new System.Drawing.Point(543, 12);
            this.txtSelectedHex.Multiline = true;
            this.txtSelectedHex.Name = "txtSelectedHex";
            this.txtSelectedHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedHex.Size = new System.Drawing.Size(282, 62);
            this.txtSelectedHex.TabIndex = 20;
            // 
            // lblSelectedAsciiLine
            // 
            this.lblSelectedAsciiLine.AutoSize = true;
            this.lblSelectedAsciiLine.Location = new System.Drawing.Point(250, 193);
            this.lblSelectedAsciiLine.Name = "lblSelectedAsciiLine";
            this.lblSelectedAsciiLine.Size = new System.Drawing.Size(89, 13);
            this.lblSelectedAsciiLine.TabIndex = 19;
            this.lblSelectedAsciiLine.Text = "No Line Selected";
            // 
            // lblSelectedHexLine
            // 
            this.lblSelectedHexLine.AutoSize = true;
            this.lblSelectedHexLine.Location = new System.Drawing.Point(250, 75);
            this.lblSelectedHexLine.Name = "lblSelectedHexLine";
            this.lblSelectedHexLine.Size = new System.Drawing.Size(89, 13);
            this.lblSelectedHexLine.TabIndex = 18;
            this.lblSelectedHexLine.Text = "No Line Selected";
            // 
            // lblAsciiLineCount
            // 
            this.lblAsciiLineCount.AutoSize = true;
            this.lblAsciiLineCount.Location = new System.Drawing.Point(419, 193);
            this.lblAsciiLineCount.Name = "lblAsciiLineCount";
            this.lblAsciiLineCount.Size = new System.Drawing.Size(92, 13);
            this.lblAsciiLineCount.TabIndex = 17;
            this.lblAsciiLineCount.Text = "Ascii Line Count =";
            // 
            // lblHexLineCount
            // 
            this.lblHexLineCount.AutoSize = true;
            this.lblHexLineCount.Location = new System.Drawing.Point(419, 75);
            this.lblHexLineCount.Name = "lblHexLineCount";
            this.lblHexLineCount.Size = new System.Drawing.Size(92, 13);
            this.lblHexLineCount.TabIndex = 16;
            this.lblHexLineCount.Text = "Hex Line Count = ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 51);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmuAscii
            // 
            this.cmuAscii.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToHexLineEquivalentToolStripMenuItem,
            this.copyAllToolStripMenuItem,
            this.copySelectedTextToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.cmuAscii.Name = "cmuAscii";
            this.cmuAscii.Size = new System.Drawing.Size(213, 92);
            // 
            // goToHexLineEquivalentToolStripMenuItem
            // 
            this.goToHexLineEquivalentToolStripMenuItem.Name = "goToHexLineEquivalentToolStripMenuItem";
            this.goToHexLineEquivalentToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.goToHexLineEquivalentToolStripMenuItem.Text = "Go To Hex Line Equivalent";
            this.goToHexLineEquivalentToolStripMenuItem.Click += new System.EventHandler(this.goToHexLineEquivalentToolStripMenuItem_Click);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // copySelectedTextToolStripMenuItem
            // 
            this.copySelectedTextToolStripMenuItem.Name = "copySelectedTextToolStripMenuItem";
            this.copySelectedTextToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.copySelectedTextToolStripMenuItem.Text = "Copy Selected Text";
            this.copySelectedTextToolStripMenuItem.Click += new System.EventHandler(this.copySelectedTextToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Strings To Remove :";
            // 
            // txtStringsToRemove
            // 
            this.txtStringsToRemove.Location = new System.Drawing.Point(123, 12);
            this.txtStringsToRemove.MaxLength = 50;
            this.txtStringsToRemove.Multiline = true;
            this.txtStringsToRemove.Name = "txtStringsToRemove";
            this.txtStringsToRemove.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStringsToRemove.Size = new System.Drawing.Size(92, 62);
            this.txtStringsToRemove.TabIndex = 12;
            // 
            // cmuHex
            // 
            this.cmuHex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToAsciiLineEquivalentToolStripMenuItem,
            this.copyAllToolStripMenuItem1,
            this.copySelectedTextToolStripMenuItem1,
            this.pasteToolStripMenuItem1});
            this.cmuHex.Name = "cmuHex";
            this.cmuHex.Size = new System.Drawing.Size(218, 92);
            // 
            // goToAsciiLineEquivalentToolStripMenuItem
            // 
            this.goToAsciiLineEquivalentToolStripMenuItem.Name = "goToAsciiLineEquivalentToolStripMenuItem";
            this.goToAsciiLineEquivalentToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.goToAsciiLineEquivalentToolStripMenuItem.Text = "Go To Ascii Line Equivalent";
            this.goToAsciiLineEquivalentToolStripMenuItem.Click += new System.EventHandler(this.goToAsciiLineEquivalentToolStripMenuItem_Click);
            // 
            // copyAllToolStripMenuItem1
            // 
            this.copyAllToolStripMenuItem1.Name = "copyAllToolStripMenuItem1";
            this.copyAllToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.copyAllToolStripMenuItem1.Text = "Copy All";
            this.copyAllToolStripMenuItem1.Click += new System.EventHandler(this.copyAllToolStripMenuItem1_Click);
            // 
            // copySelectedTextToolStripMenuItem1
            // 
            this.copySelectedTextToolStripMenuItem1.Name = "copySelectedTextToolStripMenuItem1";
            this.copySelectedTextToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.copySelectedTextToolStripMenuItem1.Text = "Copy Selected Text";
            this.copySelectedTextToolStripMenuItem1.Click += new System.EventHandler(this.copySelectedTextToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // chkEnableEdit
            // 
            this.chkEnableEdit.AutoSize = true;
            this.chkEnableEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnableEdit.Location = new System.Drawing.Point(-2, 193);
            this.chkEnableEdit.Name = "chkEnableEdit";
            this.chkEnableEdit.Size = new System.Drawing.Size(80, 17);
            this.chkEnableEdit.TabIndex = 24;
            this.chkEnableEdit.Text = "Enable Edit";
            this.chkEnableEdit.UseVisualStyleBackColor = true;
            this.chkEnableEdit.CheckedChanged += new System.EventHandler(this.chkEnableEdit_CheckedChanged);
            // 
            // txtHexDelimiter
            // 
            this.txtHexDelimiter.Location = new System.Drawing.Point(6, 19);
            this.txtHexDelimiter.Name = "txtHexDelimiter";
            this.txtHexDelimiter.Size = new System.Drawing.Size(100, 20);
            this.txtHexDelimiter.TabIndex = 25;
            this.txtHexDelimiter.Text = "0D";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(112, 17);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 22);
            this.btnApply.TabIndex = 26;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHexDelimiter);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Location = new System.Drawing.Point(221, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 45);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hex Delimiter";
            // 
            // txtHex
            // 
            this.txtHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHex.Location = new System.Drawing.Point(-2, 91);
            this.txtHex.Name = "txtHex";
            this.txtHex.Size = new System.Drawing.Size(827, 99);
            this.txtHex.TabIndex = 29;
            this.txtHex.Text = "";
            this.txtHex.Click += new System.EventHandler(this.txtHex_Click);
            this.txtHex.TextChanged += new System.EventHandler(this.txtHex_TextChanged);
            this.txtHex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtHex_MouseUp);
            // 
            // txtAscii
            // 
            this.txtAscii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAscii.Location = new System.Drawing.Point(-2, 216);
            this.txtAscii.Name = "txtAscii";
            this.txtAscii.ReadOnly = true;
            this.txtAscii.Size = new System.Drawing.Size(827, 122);
            this.txtAscii.TabIndex = 29;
            this.txtAscii.Text = "";
            this.txtAscii.Click += new System.EventHandler(this.txtAscii_Click);
            // 
            // frmHexToAscii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 338);
            this.Controls.Add(this.txtAscii);
            this.Controls.Add(this.txtHex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSelectedHex);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSelectedAsciiLine);
            this.Controls.Add(this.lblSelectedHexLine);
            this.Controls.Add(this.lblAsciiLineCount);
            this.Controls.Add(this.lblHexLineCount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkEnableEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStringsToRemove);
            this.Name = "frmHexToAscii";
            this.Text = "frmHexToAscii";
            this.Load += new System.EventHandler(this.frmHexToAscii_Load);
            this.cmuAscii.ResumeLayout(false);
            this.cmuHex.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectedHex;
        private System.Windows.Forms.Label lblSelectedAsciiLine;
        private System.Windows.Forms.Label lblSelectedHexLine;
        private System.Windows.Forms.Label lblAsciiLineCount;
        private System.Windows.Forms.Label lblHexLineCount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStringsToRemove;
        private System.Windows.Forms.ContextMenuStrip cmuAscii;
        private System.Windows.Forms.ToolStripMenuItem goToHexLineEquivalentToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmuHex;
        private System.Windows.Forms.ToolStripMenuItem goToAsciiLineEquivalentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkEnableEdit;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copySelectedTextToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtHexDelimiter;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtHex;
        private System.Windows.Forms.RichTextBox txtAscii;
    }
}