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
    public partial class frmBackupRestore : Form
    {
        CommunicationManagerOSAI comm = new CommunicationManagerOSAI();


        public frmBackupRestore()
        {
            InitializeComponent();

            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

            //Registers my DoWork, ProgressChanged, and RunWorkerCompleted methods
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            //backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //I created an extension method that gets the values of type T from anonymously typed objects
            //string objString = e.Argument.GetValueFromAnonymousType<string>("commandName");

            switch (e.Argument.GetValueFromAnonymousType<string>("commandName"))
            {
                case "Backup":
                    if (chkBkpCharacterization.Checked)
                        comm.RecieveCharacterization(txtCharBkpFilePath.Text);
                    if (chkBkpUserMemory1.Checked)
                        comm.RecieveUserMemory1(txtUM1BkpFilePath.Text);
                    if (chkBkpUserMemory2.Checked)
                        comm.RecieveUserMemory2(txtUM2BkpFilePath.Text);
                    if (chkBkpMessages.Checked)
                        comm.RecieveMessages(txtMessageBkpFilePath.Text);
                    break;
                case "Restore":
                    if (chkRestoreCharacterization.Checked)
                        comm.SendCharacterization(txtCharRestoreFilePath.Text);
                    if (chkRestoreUserMemory1.Checked)
                        comm.SendUserMemory1(txtUM1RestoreFilePath.Text);
                    if (chkRestoreUserMemory2.Checked)
                        comm.SendUserMemory2(txtUM2RestoreFilePath.Text);
                    if (chkRestoreMessages.Checked)
                        comm.SendMessages(txtMessageRestoreFilePath.Text);
                    break;
                case "Reset":
                    comm.Reset();
                    break;
                default:
                    break;
            }

            //sends this value to RunWorkerCompleted so that I can tell which method called this.
            e.Result = new { commandName = e.Argument.GetValueFromAnonymousType<string>("commandName") };

            //if (worker.CancellationPending == true)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
            }
            else if (e.Error != null)
            {
                rtbDisplay.AppendText(Environment.NewLine + "Error: " + e.Error.Message + Environment.NewLine);
                rtbDisplay.ScrollToCaret();
            }
            else
            {
                rtbDisplay.AppendText(Environment.NewLine + "Action Completed Successfully!" + Environment.NewLine);
                rtbDisplay.ScrollToCaret();
            }
        }

        private void frmBackupRestore_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        private void LoadValues()
        {
            string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            comm.SetPortNameValues(cboPort);
            comm.SetParityValues(cboParity);
            comm.SetStopBitValues(cboStop);

            foreach (TextBox txtControl in grpBackup.Controls.OfType<TextBox>())
            {
                if (txtControl.Name.Contains("Char"))
                    txtControl.Text = strDesktopPath + "\\CHA.CHA";
                else if (txtControl.Name.Contains("UM1"))
                    txtControl.Text = strDesktopPath + "\\UM1.UM1";
                else if (txtControl.Name.Contains("UM2"))
                    txtControl.Text = strDesktopPath + "\\UM2.UM2";
                else if (txtControl.Name.Contains("Message"))
                    txtControl.Text = strDesktopPath + "\\MSG.MSG";
            }
            foreach (TextBox txtControl in grpRestore.Controls.OfType<TextBox>())
            {
                if (txtControl.Name.Contains("Char"))
                    txtControl.Text = strDesktopPath + "\\CHA.CHA";
                else if (txtControl.Name.Contains("UM1"))
                    txtControl.Text = strDesktopPath + "\\UM1.UM1";
                else if (txtControl.Name.Contains("UM2"))
                    txtControl.Text = strDesktopPath + "\\UM2.UM2";
                else if (txtControl.Name.Contains("Message"))
                    txtControl.Text = strDesktopPath + "\\MSG.MSG";
            }
        }

        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "2400";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 2;
            cboData.SelectedIndex = 1;
        }

        private void SetControlState()
        {
            cmdClose.Enabled = false;
            cmdBackup.Enabled = false;
            cmdRestore.Enabled = false;
            cmdReset.Enabled = false;
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            comm.PortName = cboPort.SelectedItem.ToString();//needed this when I added usb-to-serial adapter
            comm.CurrentTransmissionType = CommunicationManagerOSAI.TransmissionType.TextWithAddedHex;
            comm.Parity = cboParity.Text;
            comm.StopBits = cboStop.Text;
            comm.DataBits = cboData.Text;
            comm.BaudRate = cboBaud.Text;
            comm.DisplayWindow = rtbDisplay;
            comm.OpenPort();

            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdReset.Enabled = true;

            cmdBackup.Enabled = true;
            cmdRestore.Enabled = true;

            cboPort.Enabled = false;
            cboBaud.Enabled = false;
            cboParity.Enabled = false;
            cboStop.Enabled = false;
            cboData.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            comm.ClosePort();

            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdReset.Enabled = false;

            cmdBackup.Enabled = false;
            cmdRestore.Enabled = false;

            cboPort.Enabled = true;
            cboBaud.Enabled = true;
            cboParity.Enabled = true;
            cboStop.Enabled = true;
            cboData.Enabled = true;
        }

        private void cmdGetCharBkpFilePath_Click(object sender, EventArgs e)
        {
            sfdChaFile.FileName = "CHA.CHA";


            if (sfdChaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCharBkpFilePath.Text = sfdChaFile.FileName;
            }
        }

        private void cmdGetUM1BkpFilePath_Click(object sender, EventArgs e)
        {
            sfdUM1File.FileName = "UM1.UM1";


            if (sfdUM1File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtUM1BkpFilePath.Text = sfdUM1File.FileName;
            }
        }

        private void cmdGetUM2bkpFilePath_Click(object sender, EventArgs e)
        {
            sfdUM2File.FileName = "UM2.UM2";


            if (sfdUM2File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtUM2BkpFilePath.Text = sfdUM2File.FileName;
            }
        }

        private void cmdGetMessagesbkpFilePath_Click(object sender, EventArgs e)
        {
            sfdMessageFile.FileName = "MSG.msg";


            if (sfdMessageFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMessageBkpFilePath.Text = sfdMessageFile.FileName;
            }
        }

        private void chkBkpCharacterization_CheckedChanged(object sender, EventArgs e)
        {
            txtCharBkpFilePath.Enabled = chkBkpCharacterization.Checked;
            cmdGetCharBkpFilePath.Enabled = chkBkpCharacterization.Checked;
        }

        private void chkBkpUserMemory1_CheckedChanged(object sender, EventArgs e)
        {
            txtUM1BkpFilePath.Enabled = chkBkpUserMemory1.Checked;
            cmdGetUM1BkpFilePath.Enabled = chkBkpUserMemory1.Checked;
        }

        private void chkBkpUserMemory2_CheckedChanged(object sender, EventArgs e)
        {
            txtUM2BkpFilePath.Enabled = chkBkpUserMemory2.Checked;
            cmdGetUM2bkpFilePath.Enabled = chkBkpUserMemory2.Checked;
        }

        private void chkBkpMessages_CheckedChanged(object sender, EventArgs e)
        {
            txtMessageBkpFilePath.Enabled = chkBkpMessages.Checked;
            cmdGetMessagesbkpFilePath.Enabled = chkBkpMessages.Checked;
        }

        private void cmdGetCharRestoreFilePath_Click(object sender, EventArgs e)
        {
            ofdChaFile.FileName = "CHA.CHA";


            if (ofdChaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCharRestoreFilePath.Text = ofdChaFile.FileName;
            }
            
        }

        private void cmdGetUM1RestoreFilePath_Click(object sender, EventArgs e)
        {
            ofdUM1File.FileName = "UM1.um1";


            if (ofdUM1File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtUM1RestoreFilePath.Text = ofdUM1File.FileName;
            }
        }

        private void cmdGetUM2RestoreFilePath_Click(object sender, EventArgs e)
        {
            ofdUM2File.FileName = "UM2.um2";


            if (ofdUM2File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtUM2RestoreFilePath.Text = ofdUM2File.FileName;
            }
        }

        private void cmdGetMessagesRestoreFilePath_Click(object sender, EventArgs e)
        {
            ofdMessageFile.FileName = "MSG.msg";


            if (ofdMessageFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMessageRestoreFilePath.Text = ofdMessageFile.FileName;
            }
            
        }

        private void chkRestoreCharacterization_CheckedChanged(object sender, EventArgs e)
        {
            txtCharRestoreFilePath.Enabled = chkRestoreCharacterization.Checked;
            cmdGetCharRestoreFilePath.Enabled = chkRestoreCharacterization.Checked;
        }

        private void chkRestoreUserMemory1_CheckedChanged(object sender, EventArgs e)
        {
            txtUM1RestoreFilePath.Enabled = chkRestoreUserMemory1.Checked;
            cmdGetUM1RestoreFilePath.Enabled = chkRestoreUserMemory1.Checked;
        }

        private void chkRestoreUserMemory2_CheckedChanged(object sender, EventArgs e)
        {
            txtUM2RestoreFilePath.Enabled = chkRestoreUserMemory2.Checked;
            cmdGetUM2RestoreFilePath.Enabled = chkRestoreUserMemory2.Checked;
        }

        private void chkRestoreMessages_CheckedChanged(object sender, EventArgs e)
        {
            txtMessageRestoreFilePath.Enabled = chkRestoreMessages.Checked;
            cmdGetMessagesRestoreFilePath.Enabled = chkRestoreMessages.Checked;
        }

        private void cmdBackup_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "Backup" });
            }
            else
                MessageBox.Show("Wait for background process to finish.  Try again later.", "Wait...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdRestore_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "Restore" });
            }
            else
                MessageBox.Show("Wait for background process to finish.  Try again later.", "Wait...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "Reset" });
            }
            else
                MessageBox.Show("Wait for background process to finish.  Try again later.", "Wait...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmBackupRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmdClose.Enabled)
                comm.ClosePort();
        }
    }
}
