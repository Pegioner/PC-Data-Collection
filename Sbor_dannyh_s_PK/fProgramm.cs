using System;
using System.Management;
using System.Windows.Forms;

namespace Sbor_dannyh_s_PK
{
    public partial class fProgramm : Form
    {
        public fProgramm()
        {
            InitializeComponent();
        }

        private void fProgramm_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Programm =
        new ManagementObjectSearcher("root\\CIMV2",
           "SELECT * FROM Win32_Product");

            int i = 0;
            foreach (ManagementObject queryObj in searcher_Programm.Get())
            { i++; string d = queryObj["InstallDate"].ToString(); DGProgramm.Rows.Add(i, queryObj["Caption"], d.Substring(6, 2) + "." + d.Substring(4, 2) + "." + d.Substring(0, 4)); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Programm =
        new ManagementObjectSearcher("root\\CIMV2",
           "SELECT * FROM Win32_Product");

            DGProgramm.Rows.Clear();
            int i = 0;
            foreach (ManagementObject queryObj in searcher_Programm.Get())
            { i++; DGProgramm.Rows.Add(i, queryObj["Caption"], queryObj["InstallDate"]); }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
