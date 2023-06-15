using System;
using System.Windows.Forms;
using System.Management;

namespace Sbor_dannyh_s_PK
{
    public partial class fOS : Form
    {
        public fOS()
        {
            InitializeComponent();
        }

        private void fOS_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher_OS =
        new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject queryObj in searcher_OS.Get())    
            { 
                DGOS.Rows.Add("Номер сборки", queryObj["BuildNumber"]);
                DGOS.Rows.Add("Название", queryObj["Caption"]);
                DGOS.Rows.Add("Свободная физическая память", queryObj["FreePhysicalMemory"]);
                DGOS.Rows.Add("Свободная виртуальная память", queryObj["FreeVirtualMemory"]);
                DGOS.Rows.Add("Имя", queryObj["Name"]);
                DGOS.Rows.Add("Тип ОС", queryObj["OSType"]);
                DGOS.Rows.Add("Авторизованный пользователь", queryObj["RegisteredUser"]);
                DGOS.Rows.Add("Серийный номер}", queryObj["SerialNumber"]);
                DGOS.Rows.Add("Старшая версия ServicePack", queryObj["ServicePackMajorVersion"]);
                DGOS.Rows.Add("Младшая версия ServicePack", queryObj["ServicePackMinorVersion"]);
                DGOS.Rows.Add("Статус", queryObj["Status"]);
                DGOS.Rows.Add("Системное устройство", queryObj["SystemDevice"]);
                DGOS.Rows.Add("Системная директория", queryObj["SystemDirectory"]);
                DGOS.Rows.Add("Системный диск", queryObj["SystemDrive"]);
                DGOS.Rows.Add("Версия", queryObj["Version"]);
                DGOS.Rows.Add("Windows директория", queryObj["WindowsDirectory"]);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DGOS.Rows.Clear();
            ManagementObjectSearcher searcher_OS =
        new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject queryObj in searcher_OS.Get())
            {
                DGOS.Rows.Add("BuildNumber", queryObj["BuildNumber"]);
                DGOS.Rows.Add("Caption", queryObj["Caption"]);
                DGOS.Rows.Add("FreePhysicalMemory", queryObj["FreePhysicalMemory"]);
                DGOS.Rows.Add("FreeVirtualMemory", queryObj["FreeVirtualMemory"]);
                DGOS.Rows.Add("Name", queryObj["Name"]);
                DGOS.Rows.Add("OSType", queryObj["OSType"]);
                DGOS.Rows.Add("RegisteredUser", queryObj["RegisteredUser"]);
                DGOS.Rows.Add("SerialNumber}", queryObj["SerialNumber"]);
                DGOS.Rows.Add("ServicePackMajorVersion", queryObj["ServicePackMajorVersion"]);
                DGOS.Rows.Add("ServicePackMinorVersion", queryObj["ServicePackMinorVersion"]);
                DGOS.Rows.Add("Status", queryObj["Status"]);
                DGOS.Rows.Add("SystemDevice", queryObj["SystemDevice"]);
                DGOS.Rows.Add("SystemDirectory", queryObj["SystemDirectory"]);
                DGOS.Rows.Add("SystemDrive", queryObj["SystemDrive"]);
                DGOS.Rows.Add("Version", queryObj["Version"]);
                DGOS.Rows.Add("WindowsDirectory", queryObj["WindowsDirectory"]);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
