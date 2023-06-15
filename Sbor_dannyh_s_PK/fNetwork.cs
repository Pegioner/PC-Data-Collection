using System;
using System.Windows.Forms;
using System.Management;

namespace Sbor_dannyh_s_PK
{
    public partial class fNetwork : Form
    {
        public fNetwork()
        {
            InitializeComponent();
        }

        private void fNetwork_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Network =
   new ManagementObjectSearcher("root\\CIMV2",
   "SELECT * FROM Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject queryObj in searcher_Network.Get())
            {
                cbNetwork.Items.Add(queryObj["Caption"]);
            }

            cbNetwork.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cbNetwork.Items.Clear();
            ManagementObjectSearcher searcher_Network =
   new ManagementObjectSearcher("root\\CIMV2",
   "SELECT * FROM Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject queryObj in searcher_Network.Get())
            {
                cbNetwork.Items.Add(queryObj["Caption"]);
            }
            int i;
            i = cbNetwork.SelectedIndex;
            if (i < cbNetwork.Items.Count)
            {
                cbNetwork.SelectedIndex = i;
            }
            else
            {
                cbNetwork.SelectedIndex = 0;
            }
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher =
   new ManagementObjectSearcher("root\\CIMV2",
   "SELECT * FROM Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                if (queryObj["Caption"].ToString() == cbNetwork.Text)
                {
                    DGNetwork.Rows.Clear();
                    DGNetwork.Rows.Add("Название", queryObj["Caption"]);

                    if (queryObj["DefaultIPGateway"] == null)
                        DGNetwork.Rows.Add("Основной шлюз", queryObj["DefaultIPGateway"]);
                    else
                    {
                        String[] arrDefaultIPGateway = (String[])(queryObj["DefaultIPGateway"]);
                        foreach (String arrValue in arrDefaultIPGateway)
                        {
                            DGNetwork.Rows.Add("Основной шлюз", arrValue);
                        }
                    }

                    if (queryObj["DNSServerSearchOrder"] == null)
                        DGNetwork.Rows.Add("Порядок поиска DNS сервера", queryObj["DNSServerSearchOrder"]);
                    else
                    {
                        String[] arrDNSServerSearchOrder = (String[])(queryObj["DNSServerSearchOrder"]);
                        foreach (String arrValue in arrDNSServerSearchOrder)
                        {
                            DGNetwork.Rows.Add("Порядок поиска DNS сервера", arrValue);
                        }
                    }

                    if (queryObj["IPAddress"] == null)
                        DGNetwork.Rows.Add("IP адрес", queryObj["IPAddress"]);
                    else
                    {
                        String[] arrIPAddress = (String[])(queryObj["IPAddress"]);
                        foreach (String arrValue in arrIPAddress)
                        {
                            DGNetwork.Rows.Add("IP адрес", arrValue);
                        }
                    }

                    if (queryObj["IPSubnet"] == null)
                        DGNetwork.Rows.Add("IP подсети", queryObj["IPSubnet"]);
                    else
                    {
                        String[] arrIPSubnet = (String[])(queryObj["IPSubnet"]);
                        foreach (String arrValue in arrIPSubnet)
                        {
                            DGNetwork.Rows.Add("IP подсети", arrValue);
                        }
                    }
                    DGNetwork.Rows.Add("MAC адрес", queryObj["MACAddress"]);
                    DGNetwork.Rows.Add("Сервисное назначение", queryObj["ServiceName"]);
                }
                
            }
        }
    }
}
