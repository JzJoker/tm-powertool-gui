using System;
using System.Collections.Generic;
using System.Linq;
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
using tm_powertool_gui.View.UserControls;
using tm_powertool_gui.View.UserControls.DataBackup;

namespace tm_powertool_gui.View.Pages
{
    /// <summary>
    /// Interaction logic for DataBackup.xaml
    /// </summary>
    public partial class DataBackup : Page
    {
        public DataBackup()
        {
            InitializeComponent();
        }

        private void SysInfo_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new SystemInfo();
        }
        private void Backup_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new Backup();
        }
        private void Verify_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new Restore();

        }
        private void Restore_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new Verify();

        }
    }
}
