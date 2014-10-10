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
    public partial class frmSerialPortCommunicator : Form
    {
        CommunicationManagerOSAI comm = new CommunicationManagerOSAI();
        string transType = string.Empty;


        public frmSerialPortCommunicator()
        {
            InitializeComponent();
            ToolTip objToolTip = new ToolTip();

            objToolTip.SetToolTip(txtHexToAddatEnd, "Type Hex Characters with NO spaces");
            objToolTip.AutomaticDelay = 1000;
        }

        private void frmSerialPortCommunicator_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            comm.PortName = cboPort.SelectedItem.ToString();//needed this when I added usb-to-serial adapter
            comm.Parity = cboParity.Text;
            comm.StopBits = cboStop.Text;
            comm.DataBits = cboData.Text;
            comm.BaudRate = cboBaud.Text;
            comm.DisplayWindow = rtbDisplay;
            comm.OpenPort();

            comm.UseMessageDelimiter = chkUseMessageDelimeter.Checked;

            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }

        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "9600";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;
        }

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            comm.SetPortNameValues(cboPort);
            comm.SetParityValues(cboParity);
            comm.SetStopBitValues(cboStop);
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void SetControlState()
        {
            rdoText.Checked = true;
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
            chkUseMessageDelimeter.Checked = comm.UseMessageDelimiter;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            comm.ClosePort();

            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdSend.Enabled = false;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            try
            {
                comm.HexAddedToEnd = txtHexToAddatEnd.Text;
                comm.WriteData(txtSend.Text);
            }
            catch (Exception objEx)
            {
                rtbDisplay.AppendText(Environment.NewLine + objEx.Message + Environment.NewLine);
            }
            
        }

        private void checkChanged(object sender, EventArgs e)
        {
            RadioButton objRadButton = (RadioButton)sender;

            
            if (objRadButton.Checked)
                switch (objRadButton.Name)
                {
                    case "rdoHex":
                        comm.CurrentTransmissionType = CommunicationManagerOSAI.TransmissionType.Hex;
                        break;
                    case "rdoText":
                        comm.CurrentTransmissionType = CommunicationManagerOSAI.TransmissionType.Text;
                        break;
                    case "rdoTextWithAddedHex":
                        comm.CurrentTransmissionType = CommunicationManagerOSAI.TransmissionType.TextWithAddedHex;
                        break;
                }
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtbDisplay.Text, true);
        }

        private void clearScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDisplay.SelectAll();
        }

        private void chkUseMessageDelimeter_CheckedChanged(object sender, EventArgs e)
        {
            comm.UseMessageDelimiter = chkUseMessageDelimeter.Checked;
        }

        private void cmdDisplayResponse_Click(object sender, EventArgs e)
        {
            try
            {
                string objString = txtMessageDelimiter.Text;


                /*the below string replace has to be done in order to insert the actual newline and or carriage return.
                when the value is placed from the textbox into the string, it is represented as \\r or \\n, respectively.  By doing the string.replace
                I am inserting the actual escaped character*/
                objString = objString.Replace("\\r", "\r").Replace("\\n", "\n");
                comm.MessageDelimiter = objString;
                MessageBox.Show(comm.Response);
            }
            catch (Exception objEx)
            {
                rtbDisplay.AppendText(Environment.NewLine + objEx.Message + Environment.NewLine);
            }
        }

        private void cmdDisplayResponses_Click(object sender, EventArgs e)
        {
            try
            {
                string objString = txtMessageDelimiter.Text;


                objString = objString.Replace("\\r", "\r").Replace("\\n", "\n");
                comm.MessageDelimiter = objString;
                MessageBox.Show(comm.Responses);
            }
            catch (Exception objEx)
            {
                rtbDisplay.AppendText(Environment.NewLine + objEx.Message + Environment.NewLine);
            }
        }

        private void frmSerialPortCommunicator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmdClose.Enabled)
                comm.ClosePort();
        }
    }
}
