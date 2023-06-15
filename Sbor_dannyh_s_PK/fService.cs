using System;
using System.Windows.Forms;
using System.Management;

namespace Sbor_dannyh_s_PK
{
    public partial class fService : Form
    {
        public fService()
        {
            InitializeComponent();
        }

        private void fService_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher3 =
        new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Service");

            int i = 0;
            foreach (ManagementObject queryObj in searcher3.Get())
            { i++; DGServise.Rows.Add(i, queryObj["Caption"], queryObj["DisplayName"], queryObj["Name"], queryObj["PathName"], queryObj["Started"]); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Service =
        new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Service");

            DGServise.Rows.Clear();
            int i = 0;
            foreach (ManagementObject queryObj in searcher_Service.Get())
            { i++; DGServise.Rows.Add(i, queryObj["Caption"], queryObj["DisplayName"], queryObj["Name"], queryObj["PathName"], queryObj["Started"]); }
        }

        private void DGProcess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int CurRow = e.RowIndex;

            ManagementObjectSearcher searcher_Service =
        new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Service");

            foreach (ManagementObject queryObj in searcher_Service.Get())
            { 
                if(queryObj["Name"].ToString() == DGServise[3, CurRow].Value.ToString())
                {
                    MessageBox.Show(queryObj["Description"].ToString(), queryObj["Name"].ToString());
                    break;
                }   
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
