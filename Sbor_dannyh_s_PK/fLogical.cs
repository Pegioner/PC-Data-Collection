using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Management;

namespace Sbor_dannyh_s_PK
{
    public partial class fLogical : Form
    {
        public fLogical()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void lTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fLogical_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Disk =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Volume");

            int i = 0;
            double o, f;
            foreach (ManagementObject queryObj in searcher_Disk.Get())
            {
                i++;
                DGDisk.Rows.Add(i, queryObj["Caption"],
                    queryObj["DriveType"],
                    queryObj["FileSystem"],
                    (o = Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2)) + " ГБ",
                    (f = Math.Round(System.Convert.ToDouble(queryObj["FreeSpace"]) / 1024 / 1024 / 1024, 2)) + " ГБ",
                    (o - f) + " ГБ");
            }
        }
    }
}
