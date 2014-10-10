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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void oSAIFileUtilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOSAIFileUtility frmObjOSAIFileUtility = new frmOSAIFileUtility();


            frmObjOSAIFileUtility.MdiParent = this;
            frmObjOSAIFileUtility.WindowState = FormWindowState.Maximized;
            frmObjOSAIFileUtility.Show();
        }

        private void serialPortCommunicatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSerialPortCommunicator frmObjSerialPortCommunicator = new frmSerialPortCommunicator();


            frmObjSerialPortCommunicator.MdiParent = this;
            frmObjSerialPortCommunicator.WindowState = FormWindowState.Maximized;
            frmObjSerialPortCommunicator.Show();
        }

        private void hexToAsciiConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHexToAscii frmObjHexToAscii = new frmHexToAscii();


            frmObjHexToAscii.MdiParent = this;
            frmObjHexToAscii.WindowState = FormWindowState.Maximized;
            frmObjHexToAscii.Show();
        }

        private void emulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm8600Emulator frmObj8600Emulator = new frm8600Emulator();


            frmObj8600Emulator.MdiParent = this;
            frmObj8600Emulator.WindowState = FormWindowState.Maximized;
            frmObj8600Emulator.Show();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupRestore frmObjBackupRestore = new frmBackupRestore();


            frmObjBackupRestore.MdiParent = this;
            frmObjBackupRestore.WindowState = FormWindowState.Maximized;
            frmObjBackupRestore.AutoScroll = true;
            frmObjBackupRestore.Show();
        }
    }
}
