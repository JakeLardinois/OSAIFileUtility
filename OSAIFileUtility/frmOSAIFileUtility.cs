using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;


namespace OSAIFileUtility
{
    public partial class frmOSAIFileUtility : Form
    {
        CommunicationManagerOSAI comm = new CommunicationManagerOSAI();
        private const int LINESPERBYTE = 21;


        public frmOSAIFileUtility()
        {
            InitializeComponent();
            //ToolTip objToolTip = new ToolTip();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();


            //Adds my ToolTip
            //objToolTip.SetToolTip(txtHexToAddatEnd, "Type Hex Characters with NO spaces");
            //objToolTip.AutomaticDelay = 1000;

            //Registers my DoWork, ProgressChanged, and RunWorkerCompleted methods
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            dgvProgramFileList.DataSource = CommunicationManagerOSAI.ProgramFiles;

            BindingSource objBindingSource = new BindingSource();
            objBindingSource.DataSource = CommunicationManagerOSAI.ProgramFiles;
            findStrip1.BindingSource = objBindingSource;
            findStrip1.LoadSearchProperties();
            //findStrip1.BindingSource = new BindingSource();
            //findStrip1.BindingSource.DataSource = CommunicationManagerOSAI.ProgramFiles;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string strCommandName = e.Argument.GetValueFromAnonymousType<string>("commandName");


            /*I created an extension method that gets the values of type T from anonymously typed objects.  I use that here so that I can issue different commands from my background worker based on which command was specified.
              The benefit of this when using serial communication is that you can only be working on 1 command at a time anyway, so It wouldn't make sense to have a different background worker for each command.  */
            switch (strCommandName)
            {
                case "SendFile":
                    //comm.SendFile(txtFilePath.Text);
                    e.Result = new { commandName = strCommandName, ProgramFile = comm.SendFile(txtFilePath.Text) };
                    break;
                case "RecieveFiles":
                    int intSize = 0;
                    int intLineCount = 0;
                    int intTotalLineCount = 0;
                    var objStringBuilder = new StringBuilder();


                    /*This step was added so that I could utilize a progress indicator I iterate through each of the selected rows and add up their sizes. I took an average of file sizes and an average number of lines in those files and tried to come up with a number that would tell me "given the size of a file, how many lines of text does it contain?"
                     * I had to then reduce that number to make sure that I would never go over it because that would cause an exception in my application. I use this as the basis of my progress indicator*/
                    foreach (DataGridViewRow objRow in dgvProgramFileList.SelectedRows)
                    {
                        if (int.TryParse(objRow.Cells["Size"].Value.ToString().Trim(), out intSize))
                        {
                            intTotalLineCount += intSize / LINESPERBYTE; 
                        }
                    }

                    /*I iterate through each of the selected rows and save them to the indicated path with the indicated name and specifying which program I am to copy.  I also had to pass an anonymously typed object which contains some data for my progress indicator.  The anonymous object contains a linecount and totallinecount property
                     The linecount is the line number (based on the total line count calculated above) that I am on.  When I iterate through a file copy from the osai board, This value is incremented for each line that is recieved.  I then use this value as well as the expected total line count to calculate a percentage that I am done.
                     After the ReceiveFile command completes, I increment it by the expected lines of the file so that the progress indicator handles multiple files successfully.*/
                    foreach (DataGridViewRow objRow in dgvProgramFileList.SelectedRows)
                    {
                        int.TryParse(objRow.Cells["Size"].Value.ToString().Trim(), out intSize);

                        objStringBuilder.Append(objRow.Cells["Program_Name"].Value.ToString().Trim());
                        comm.RecieveFile(e.Argument.GetValueFromAnonymousType<string>("filePath") + objStringBuilder.ToString() + "_" + string.Format("{0:yyyyMMdd}", DateTime.Now) + ".pap", objStringBuilder.ToString(), new { LineCount = intLineCount, TotalLineCount = intTotalLineCount });
                        intLineCount += intSize / LINESPERBYTE;
                        objStringBuilder.Clear();
                    }
                    //comm.RecieveFile(e.Argument.GetValueFromAnonymousType<string>("filePath"), dgvProgramFileList.CurrentRow.Cells["Program_Name"].Value.ToString().Trim());
                    e.Result = new { commandName = strCommandName };
                    break;
                case "ListDirectory":
                    comm.ListDirectory();
                    e.Result = new { commandName = strCommandName };
                    break;
                case "DeleteFiles":
                    int intCounter = 0;

                    foreach (DataGridViewRow objRow in dgvProgramFileList.SelectedRows)
                    {
                        comm.DeleteFile(string.Empty, (objRow.Cells["Program_Name"].Value.ToString().Trim()));
                        backgroundWorker1.ReportProgress(++intCounter, dgvProgramFileList.SelectedRows.Count);
                    }
                    //comm.DeleteFile(string.Empty, (dgvProgramFileList.CurrentRow.Cells["Program_Name"].Value.ToString().Trim()));
                    e.Result = new { commandName = strCommandName };
                    break;
                case "Reset":
                    comm.Reset();
                    e.Result = new { commandName = strCommandName };
                    break;
                default:
                    break;
            }

            //sends this value to RunWorkerCompleted so that I can tell which method called this.
            //e.Result = new { commandName = e.Argument.GetValueFromAnonymousType<string>("commandName") };
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                objProgressBar.Value = objProgressBar.Minimum;

                rtbDisplay.AppendText(Environment.NewLine + "Action Cancelled" + Environment.NewLine);
                rtbDisplay.ScrollToCaret();
            }
            else if (e.Error != null)
            {
                objProgressBar.Value = objProgressBar.Minimum;

                rtbDisplay.AppendText(Environment.NewLine + "Error: " + e.Error.Message + Environment.NewLine);
                rtbDisplay.ScrollToCaret();
            }
            else
            {
                string strCommandName = e.Result.GetValueFromAnonymousType<string>("commandName");
 

                objProgressBar.Value = objProgressBar.Maximum;

                switch(strCommandName)
                {
                    case "SendFile":
                        CommunicationManagerOSAI.ProgramFiles.Add(e.Result.GetValueFromAnonymousType<ProgramFile>("ProgramFile"));
                        break;
                    case "DeleteFiles":
                        foreach (DataGridViewRow objRow in dgvProgramFileList.SelectedRows)
                        {
                            dgvProgramFileList.Rows.Remove(objRow);
                        }
                        break;

                }


                dgvProgramFileList.DataSource = CommunicationManagerOSAI.ProgramFiles;
                //CommunicationManagerOSAI.ProgramFiles.ResetBindings();
                dgvProgramFileList.Columns["Program_Name"].Width = 85;
                dgvProgramFileList.Columns["Size"].Width = 40;
                rtbDisplay.AppendText(Environment.NewLine + "Action Completed Successfully!" + Environment.NewLine);
                rtbDisplay.ScrollToCaret();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //lblResultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            //objProgressBar.PerformStep();
            //objProgressBar.Value += e.ProgressPercentage;

            try
            {
                objProgressBar.Maximum = (int)e.UserState;
                objProgressBar.Value = e.ProgressPercentage;
            }
            catch (ArgumentOutOfRangeException)
            {
                objProgressBar.Value = objProgressBar.Maximum - 2;
            }
        }

        private void frmOSAIFileUtility_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
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

            cmdSendFile.Enabled = true;
            cmdListDirectory.Enabled = true;
            cmdDeleteFile.Enabled = true;
            cmdRecieveFile.Enabled = true;
            cmdReset.Enabled = true;

            cboPort.Enabled = false;
            cboBaud.Enabled = false;
            cboParity.Enabled = false;
            cboStop.Enabled = false;
            cboData.Enabled = false;
        }

        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "2400";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 2;
            cboData.SelectedIndex = 1;

        }

        private void LoadValues()
        {
            string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            comm.SetPortNameValues(cboPort);
            comm.SetParityValues(cboParity);
            comm.SetStopBitValues(cboStop);

            txtDirectoryPath.Text = strDesktopPath;
            txtFilePath.Text = strDesktopPath + "\\ProgramFile.pap";
        }

        private void SetControlState()
        {
            cmdClose.Enabled = false;
            cmdSendFile.Enabled = false;
            cmdListDirectory.Enabled = false;
            cmdDeleteFile.Enabled = false;
            cmdRecieveFile.Enabled = false;
            cmdReset.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            comm.ClosePort();

            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            
            cmdSendFile.Enabled = false;
            cmdListDirectory.Enabled = false;
            cmdDeleteFile.Enabled = false;
            cmdRecieveFile.Enabled = false;
            cmdReset.Enabled = false;

            cboPort.Enabled = true;
            cboBaud.Enabled = true;
            cboParity.Enabled = true;
            cboStop.Enabled = true;
            cboData.Enabled = true;
        }

        private void clearScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDisplay.SelectAll();
        }

        private void cmdSendFile_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true && System.IO.File.Exists(txtFilePath.Text))
            {
                Match match = Regex.Match(Path.GetFileNameWithoutExtension(txtFilePath.Text), "^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$", RegexOptions.IgnoreCase);


                if (match.Success)
                {
                    objProgressBar.Value = objProgressBar.Minimum;
                    backgroundWorker1.RunWorkerAsync(new { commandName = "SendFile" });
                }
                else
                {
                    MessageBox.Show("Program Name must be Integer value between 1 and 999", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                showWaitMessage();
        }

        private void cmdGetFilePath_Click(object sender, EventArgs e)
        {
            var objResult = ofdPapFiles.ShowDialog();


            if (objResult == DialogResult.OK)
            {
                txtFilePath.Text = ofdPapFiles.FileName;
            }
        }

        private void cmdListDirectory_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                objProgressBar.Value = objProgressBar.Minimum;
                dgvProgramFileList.DataSource = null;//I need to set this null or else I get a cross thread error 
                backgroundWorker1.RunWorkerAsync(new { commandName = "ListDirectory" });
            }
            else
                showWaitMessage();
        }

        private void cmdDeleteFile_Click(object sender, EventArgs e)
        {
            if (dgvProgramFileList.DataSource != null)
            {
                //if (MessageBox.Show("Are you sure you want to delete program " + dgvProgramFileList.CurrentRow.Cells["Program_Name"].Value.ToString().Trim() + " ?",
                //"Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                if (MessageBox.Show("Are you sure you want to delete the selected program(s)?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (backgroundWorker1.IsBusy != true)
                    {
                        objProgressBar.Value = objProgressBar.Minimum;
                        backgroundWorker1.RunWorkerAsync(new { commandName = "DeleteFiles" });
                    }
                    else
                        showWaitMessage();
                }
            }
        }

        private void cmdRecieveFile_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true)
            {
                objProgressBar.Value = objProgressBar.Minimum;
                backgroundWorker1.RunWorkerAsync(new { commandName = "RecieveFiles", filePath = txtDirectoryPath.Text + "\\" });
            }
            else
                showWaitMessage();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                objProgressBar.Value = objProgressBar.Minimum;
                backgroundWorker1.RunWorkerAsync(new { commandName = "Reset" });
            }
            else
                showWaitMessage();
        }

        private void frmOSAIFileUtility_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmdClose.Enabled)
                comm.ClosePort();
        }

        private void cmdGetDirectoryPath_Click(object sender, EventArgs e)
        {

            if (fbdSaveDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDirectoryPath.Text = fbdSaveDirectory.SelectedPath;

                //MessageBox.Show(txtDirectoryPath.Text + "\\" + "Temp" + string.Format("{0:yyyyMMdd}", DateTime.Now) + ".pap" );
            }
        }

        private void showWaitMessage()
        {
            MessageBox.Show("Wait for background process to finish.  Try again later.", "Wait...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void findStrip1_ItemFound(object sender, ItemFoundEventArgs e)
        {
            // If value found, select row
            if (e.Index >= 0)
            {
                this.dgvProgramFileList.ClearSelection();
                this.dgvProgramFileList.Rows[e.Index].Selected = true;
                this.dgvProgramFileList.CurrentCell = this.dgvProgramFileList.Rows[e.Index].Cells[0];

                // Change current list data source item
                // (to ensure currency across all controls
                // bound to this BindingSource)
                //this.wordBindingSource.Position = e.Index;
                this.findStrip1.BindingSource.Position = e.Index;
            }

        }
    }
}
