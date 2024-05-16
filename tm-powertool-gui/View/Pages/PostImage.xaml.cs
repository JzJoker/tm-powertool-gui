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
using tm_powertool_gui.View.UserControls.PostImage;

namespace tm_powertool_gui.View.Pages
{
    /// <summary>
    /// Interaction logic for PostImage.xaml
    /// </summary>
    public partial class PostImage : Page
    {
        public PostImage()
        {
            InitializeComponent();
        }

        private void SysInfo_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new SystemInfo();
        }

        private void Dell_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new DellCommandUpdate();
        }

        private void Windows_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new WindowsUpdate();
        }

        private void SentOne_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new SentinelOne();
        }

        private void Bomgar_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new BomgarJumpClient();
        }
    }
}
