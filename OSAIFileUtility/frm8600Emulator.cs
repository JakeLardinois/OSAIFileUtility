using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OSAIFileUtility
{
    public partial class frm8600Emulator : Form
    {
        CommunicationManagerOSAI comm = new CommunicationManagerOSAI();
        string transType = string.Empty;


        public frm8600Emulator()
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
            CommandBuilder objCommandBuilder;
            List<string> SendCommands;
            List<string> RecieveCommands;
            StringBuilder objStringBuilder = new StringBuilder();


            //I created an extension method that gets the values of type T from anonymously typed objects
            string objString = e.Argument.GetValueFromAnonymousType<string>("commandName");

            switch (e.Argument.GetValueFromAnonymousType<string>("commandName"))
            {
                case "EmulateFileUpload":
                    objCommandBuilder = new CommandBuilder(txtFilePath.Text, CommandBuilder.CommandTypes.SendFile);
                    SendCommands = objCommandBuilder.SendCommands;
                    RecieveCommands = objCommandBuilder.RecieveCommands;

                    comm.MessageDelimiter = "\r\n";
                    comm.UseMessageDelimiter = true;
                    comm.HexAddedToEnd = string.Empty;

                    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
                    {
                        comm.WaitForMessage(20);
                        if (comm.Response.Equals(SendCommands[intCounter]))
                        {
                            comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                        }
                        else
                            throw new Exception("Unrecognized Command!");
                    }
                    break;
                case "EmulateDir":
                    objCommandBuilder = new CommandBuilder(string.Empty, CommandBuilder.CommandTypes.ListDirectory);
                    SendCommands = objCommandBuilder.SendCommands;
                    RecieveCommands = objCommandBuilder.RecieveCommands;

                    comm.MessageDelimiter = "\r\n";
                    comm.UseMessageDelimiter = true;
                    comm.HexAddedToEnd = string.Empty;

                    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
                    {
                        switch (intCounter)
                        {
                            case 0: case 1: case 8: case 9:
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                    break;
                                }
                                else
                                    throw new Exception("Unrecognized Response");
                            case 2: case 3: case 4: case 5: case 10: case 11: case 12: case 13:
                                comm.HexAddedToEnd = "0D";
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                    break;
                                }
                                else
                                    throw new Exception("Unrecognized Response");
                            case 6: case 14:
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    for (int intCounter2 = 0; intCounter2 < 10; ++intCounter2)
                                    {
                                        //comm.WriteDataFromEmulator(("" + intCounter2).PadLeft(10) + ("" + Math.Pow(intCounter2, 3)).PadLeft(8) + "  Description of Program File.");
                                        comm.WriteDataFromEmulator("       180    2158  #11384 BASCO MAN#3A 3B2 3C5 .312 CB. BF. FR");
                                        comm.WaitForMessage(20);
                                        if (comm.Responses.Equals(SendCommands[intCounter]))
                                            continue;
                                        else
                                            throw new Exception("Unrecognized Response");
                                    }
                                    comm.HexAddedToEnd = string.Empty;
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                }
                                break;
                            case 7: case 15:
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                    break;
                                }
                                else
                                    throw new Exception("Unrecognized Response");
                            default:
                                break;
                        }
                    }
                    break;
                case "EmulateDelete":
                    objCommandBuilder = new CommandBuilder(string.Empty, CommandBuilder.CommandTypes.DeleteFile);
                    SendCommands = objCommandBuilder.SendCommands;
                    RecieveCommands = objCommandBuilder.RecieveCommands;

                    comm.MessageDelimiter = "\r\n";
                    comm.UseMessageDelimiter = true;
                    comm.HexAddedToEnd = string.Empty;

                    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
                    {
                        switch (intCounter)
                        {
                            case 1:
                                comm.WaitForMessage(20);
                                if (comm.Response.Contains(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                }
                                else
                                    throw new Exception("Unrecognized Command!");
                                break;
                            default:
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                }
                                else
                                    throw new Exception("Unrecognized Command!");
                                break;
                        }
                        
                    }
                    break;
                case "EmulateFileDownload":
                    objCommandBuilder = new CommandBuilder(txtFilePath.Text, CommandBuilder.CommandTypes.RecieveFile);
                    SendCommands = objCommandBuilder.SendCommands;
                    RecieveCommands = objCommandBuilder.RecieveCommands;
                    List<string> strListFileContents = new List<string>();
                    string strLine = string.Empty;
                    int intFileLines = 0;

                    comm.MessageDelimiter = "\r\n";
                    comm.UseMessageDelimiter = true;
                    comm.HexAddedToEnd = string.Empty;


                    using (StreamReader objReader = new StreamReader(txtFilePath.Text))
                    {
                        while ((strLine = objReader.ReadLine()) != null)
                        {
                            strListFileContents.Add(strLine);
                            intFileLines++;
                        }
                    }


                    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
                    {
                        switch (intCounter)
                        {
                            case 0:
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                    break;
                                }
                                else
                                    throw new Exception("Unrecognized Response");
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                                comm.HexAddedToEnd = "0D";
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                    break;
                                }
                                else
                                    throw new Exception("Unrecognized Response");
                            case 5:
                                comm.HexAddedToEnd = "0D";
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    for (int intCounter2 = 0; intCounter2 < intFileLines; ++intCounter2)
                                    {
                                        comm.WriteDataFromEmulator((string.Empty + (intCounter2 + 1) + '-').PadLeft(6).Insert(0, "I") + strListFileContents[intCounter2]);
                                        //comm.WriteDataFromEmulator("COM/ MAN#3A-B2-C2   .312 BEND FINGER #31");
                                        //comm.WriteDataFromEmulator("       879    2158  #11384 BASCO MAN#3A 3B2 3C5 .312 CB. BF. FR");
                                        comm.WaitForMessage(20);
                                        if (comm.Responses.Equals(SendCommands[intCounter]))
                                            continue;
                                        else
                                            throw new Exception("Unrecognized Response");
                                    }
                                    comm.HexAddedToEnd = string.Empty;
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                }
                                break;
                            case 6:
                                comm.HexAddedToEnd = string.Empty;
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                    break;
                                }
                                else
                                    throw new Exception("Unrecognized Response");
                            default:
                                break;
                        }
                    }
                    break;
                case "EmulateReset":
                    objCommandBuilder = new CommandBuilder(string.Empty, CommandBuilder.CommandTypes.Reset);
                    SendCommands = objCommandBuilder.SendCommands;
                    RecieveCommands = objCommandBuilder.RecieveCommands;

                    comm.MessageDelimiter = "\r\n";
                    comm.UseMessageDelimiter = true;
                    comm.HexAddedToEnd = string.Empty;

                    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
                    {
                        switch (intCounter)
                        {
                            case 0:
                                comm.WaitForMessage(20);
                                if (comm.Response.Contains(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                }
                                else
                                    throw new Exception("Unrecognized Command!");
                                break;
                            default:
                                comm.WaitForMessage(20);
                                if (comm.Response.Equals(SendCommands[intCounter]))
                                {
                                    comm.WriteDataFromEmulator(RecieveCommands[intCounter]);
                                }
                                else
                                    throw new Exception("Unrecognized Command!");
                                break;
                        }
                        
                    }
                    break;
                default:
                    break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                rtbDisplay.AppendText(Environment.NewLine + "Action Cancelled" + Environment.NewLine);
                rtbDisplay.ScrollToCaret();
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

        private void frm8600Emulator_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "9600";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;

        }

        private void LoadValues()
        {
            comm.SetPortNameValues(cboPort);
            comm.SetParityValues(cboParity);
            comm.SetStopBitValues(cboStop);
        }

        private void SetControlState()
        {
            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdEmulateFileUpload.Enabled = false;
            cmdEmulateDir.Enabled = false;
            cmdEmulateDelete.Enabled = false;
            cmdEmulateFileDownload.Enabled = false;
            cmdEmulateReset.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            comm.ClosePort();

            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdEmulateFileUpload.Enabled = false;
            cmdEmulateDir.Enabled = false;
            cmdEmulateDelete.Enabled = false;
            cmdEmulateFileDownload.Enabled = false;
            cmdEmulateReset.Enabled = false;
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
            cmdEmulateFileUpload.Enabled = true;
            cmdEmulateDir.Enabled = true;
            cmdEmulateDelete.Enabled = true;
            cmdEmulateFileDownload.Enabled = true;
            cmdEmulateReset.Enabled = true;
        }

        private void cmdEmulateFileUpload_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "EmulateFileUpload" });
            }
        }

        private void cmdEmulateDir_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "EmulateDir" });
            }
        }

        private void cmdEmulateDelete_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "EmulateDelete" });
            }
        }

        private void cmdEmulateFileDownload_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "EmulateFileDownload" });
            }
        }

        private void btnGetFilePath_Click(object sender, EventArgs e)
        {
            var objResult = ofdPapFiles.ShowDialog();


            if (objResult == DialogResult.OK)
            {
                txtFilePath.Text = ofdPapFiles.FileName;
            }
        }

        private void cmdEmulateReset_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new { commandName = "EmulateReset" });
            }
        }

        private void frm8600Emulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmdClose.Enabled)
                comm.ClosePort();
        }
    }
}
