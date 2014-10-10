using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSAIFileUtility
{
    public partial class frmHexToAscii : Form
    {
        public frmHexToAscii()
        {
            InitializeComponent();
        }

        private void txtHex_TextChanged(object sender, EventArgs e)
        {
            int intAsciiLineCount = 0, intHexLineCount = 0;


            try
            {
                txtAscii.Text = HexToAscii.ConvertToAscii(txtHex.Text, txtStringsToRemove.Text, txtHexDelimiter.Text);
            }
            catch(Exception objEx)
            {
                txtAscii.Text = objEx.Message;
            }

            intAsciiLineCount = txtAscii.Lines.Count() - 1;
            intHexLineCount = txtHex.Lines.Count() - 1;
            lblAsciiLineCount.Text = string.Format("Ascii Line Count = {0}", intAsciiLineCount);
            lblHexLineCount.Text = string.Format("Hex Line Count = {0}", intHexLineCount);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHex.Clear();
            txtHex.Focus();
        }

        private void txtHex_Click(object sender, EventArgs e)
        {
            lblSelectedHexLine.Text = string.Format("Hex Line {0} is selected", txtHex.CurrentLine());
        }

        private void frmHexToAscii_Load(object sender, EventArgs e)
        {
            txtStringsToRemove.Text = "RX:\r\n[\r\n]";
        }

        private void txtAscii_Click(object sender, EventArgs e)
        {
            lblSelectedAsciiLine.Text = string.Format("Ascii Line {0} is selected", txtAscii.CurrentLine());
        }

        private void txtHex_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                txtSelectedHex.Text = HexToAscii.ConvertToAscii(txtHex.SelectedText, txtStringsToRemove.Text);
            }
            catch(Exception objEx)
            {
                txtSelectedHex.Text = objEx.Message;
            }
            
        }

        private void goToHexLineEquivalentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] HexLines = txtHex.Lines;


            try
            {
                txtHex.SelectLine(txtAscii.CurrentLine(), HexLines[txtAscii.CurrentLine() - 1].Length);
            }
            catch{ }
        }

        private void goToAsciiLineEquivalentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] AsciiLines = txtAscii.Lines;


            try
            {
                txtAscii.SelectLine(txtHex.CurrentLine(), AsciiLines[txtHex.CurrentLine() - 1].Length);
            }
            catch{ }
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtAscii.Text, true);
        }

        private void copySelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtAscii.SelectedText, true);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text) && !txtAscii.ReadOnly)
                txtAscii.Text = (string)data.GetData(DataFormats.Text);
        }

        private void chkEnableEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableEdit.Checked)
                txtAscii.ReadOnly = false;
            else
                txtAscii.ReadOnly = true;
        }

        private void copyAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtHex.Text, true);
        }

        private void copySelectedTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtHex.SelectedText, true);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
                txtHex.Text = (string)data.GetData(DataFormats.Text);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            txtHex_TextChanged(sender, e);
            //int intAsciiLineCount = 0, intHexLineCount = 0;


            //try
            //{
            //    txtAscii.Text = HexToAscii.ConvertToAscii(txtHex.Text, txtStringsToRemove.Text);
            //}
            //catch (Exception objEx)
            //{
            //    txtAscii.Text = objEx.Message;
            //}

            //intAsciiLineCount = txtAscii.Lines.Count() - 1;
            //intHexLineCount = txtHex.Lines.Count() - 1;
            //lblAsciiLineCount.Text = string.Format("Ascii Line Count = {0}", intAsciiLineCount);
            //lblHexLineCount.Text = string.Format("Hex Line Count = {0}", intHexLineCount);
        }
    }
}
