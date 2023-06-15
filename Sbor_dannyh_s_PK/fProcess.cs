using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sbor_dannyh_s_PK
{
    public partial class fProcess : Form
    {
        public fProcess()
        {
            InitializeComponent();
        }

        private void Process_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Process pr in Process.GetProcesses())
            { i++; DGProcess.Rows.Add(i, pr.ProcessName.ToString(), pr.Id.ToString(), Math.Round(Convert.ToDouble(pr.WorkingSet64) / 1024 / 1024, 2).ToString() + " МБ"); }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DGProcess.Rows.Clear();
            int i = 0;
            foreach (Process pr in Process.GetProcesses())
            { i++; DGProcess.Rows.Add(i, pr.ProcessName.ToString(), pr.Id.ToString(), Math.Round(Convert.ToDouble(pr.WorkingSet64) / 1024 / 1024, 2).ToString() + " МБ"); }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
