using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Globalization;

namespace tm_powertool_gui.View.UserControls
{
    /// <summary>
    /// Interaction logic for SystemInfo.xaml
    /// </summary>
    public partial class SystemInfo : UserControl
    {
        public string Hostname { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }
        public string WindowsVersion { get; set; }
        public string SystemType { get; set; }
        public string DeviceModel { get; set; }
        public string SerialNumber { get; set; }
        public string BiosVersion { get; set; }
        public string BiosDate { get; set; }



        public SystemInfo()
        {
            InitializeComponent();

            Hostname = System.Net.Dns.GetHostName();
            Domain = System.Environment.UserDomainName;
            Username = System.Environment.UserName;
            WindowsVersion = GetCleanWindowsVersion();
            SystemType = System.Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            DeviceModel = GetDeviceModel();
            SerialNumber = GetSerialNumber();
            BiosVersion = GetBiosVersion();
            BiosDate = GetFormattedBiosDate();

            txtHostname.Text = Hostname;
            txtDomain.Text = Domain;
            txtUsername.Text = Username;
            txtWindowsVersion.Text = WindowsVersion;
            txtSystemType.Text = SystemType;
            txtDeviceModel.Text = DeviceModel;
            txtSerialNumber.Text = SerialNumber;
            txtBiosVersion.Text = BiosVersion;
            txtBiosDate.Text = BiosDate;
        }
        private string GetDeviceModel()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        return obj["Model"].ToString();
                    }
                }
            }
            catch (ManagementException)
            {
                MessageBox.Show("Device Model could not be retrieved");
            }
            return "Unknown";
        }
        private string GetSerialNumber()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        return obj["SerialNumber"].ToString();
                    }
                }
            }
            catch (ManagementException)
            {
                MessageBox.Show("Serial Number could not be retrieved");
            }
            return "Unknown";
        }

        private string GetBiosVersion()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT SMBIOSBIOSVersion FROM Win32_BIOS"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        return obj["SMBIOSBIOSVersion"].ToString();
                    }
                }
            }
            catch (ManagementException)
            {
                MessageBox.Show("Bios Version could not be retrieved");
            }
            return "Unknown";
        }

        private string GetBiosDate()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT ReleaseDate FROM Win32_BIOS"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        return obj["ReleaseDate"].ToString();
                    }
                }
            }
            catch (ManagementException)
            {
                MessageBox.Show("Bios Date Could not be retrieved");
            }
            return "Unknown";
        }
        private string GetCleanWindowsVersion()
        {
            string fullVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            if (fullVersion.Contains("Microsoft Windows"))
            {
                return fullVersion.Replace("Microsoft Windows", "").Trim();
            }
            return fullVersion;
        }

        private string GetFormattedBiosDate()
        {
            string biosDate = GetBiosDate();
            string datePart = biosDate.Substring(0, 8);
            DateTime date;
            if (DateTime.TryParseExact(datePart, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date.ToString("MM/dd/yyyy");
            }
            return biosDate;
        }

    }
}
