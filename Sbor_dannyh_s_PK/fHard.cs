using System;
using System.Windows.Forms;
using System.Management;

namespace Sbor_dannyh_s_PK
{
    public partial class fHard : Form
    {
        public fHard()
        {
            InitializeComponent();
        }

        private void fHard_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Video =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher_Video.Get())
            {
                DGVideo.Rows.Add("Объем видеопамяти", queryObj["AdapterRAM"]);
                DGVideo.Rows.Add("Название", queryObj["Caption"]);
                DGVideo.Rows.Add("Описание", queryObj["Description"]);
                DGVideo.Rows.Add("Видеопроцессор", queryObj["VideoProcessor"]);
            }


            ManagementObjectSearcher searcher_Proc =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher_Proc.Get())
            {
                DGProc.Rows.Add("Название", queryObj["Name"]);
                DGProc.Rows.Add("Количество ядер", queryObj["NumberOfCores"]);
                DGProc.Rows.Add("Id процессора", queryObj["ProcessorId"]);
            }


            ManagementObjectSearcher searcher_Op =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_PhysicalMemory");

            int i = 0;
            foreach (ManagementObject queryObj in searcher_Op.Get())
            { i++; DGOp.Rows.Add(i ,queryObj["BankLabel"], Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2), queryObj["Speed"]);}



            ManagementObjectSearcher searcher_Hard =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject queryObj in searcher_Hard.Get())
            { cbHard.Items.Add(queryObj["DeviceID"]); }

            cbHard.SelectedIndex = 0;

            btnLogical.BringToFront();
            ToolTip t = new ToolTip();
            t.SetToolTip(btnLogical, "Логические диски");

        }

        private void cbHard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_Hard =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject queryObj in searcher_Hard.Get())
            {
                if(queryObj["DeviceID"].ToString() == cbHard.Text)
                {
                    DGHard.Rows.Clear();
                    DGHard.Rows.Add("Код (ID) диска", queryObj["DeviceID"]);
                    DGHard.Rows.Add("Тип интерфейса", queryObj["InterfaceType"]);
                    DGHard.Rows.Add("Производитель", queryObj["Manufacturer"]);
                    DGHard.Rows.Add("Модель", queryObj["Model"]);
                    DGHard.Rows.Add("Серийный номер", queryObj["SerialNumber"]);
                    DGHard.Rows.Add("Объем, ГБ", Math.Round(Convert.ToDouble(queryObj["Size"]) / 1024 / 1024 / 1024, 2));
                }
                
            }
        }

        private void btnLogical_Click(object sender, EventArgs e)
        {
            fLogical frm = new fLogical();
            frm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
