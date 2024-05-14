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


namespace tm_powertool_gui.View.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void StartPostButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to PostImage.xaml
            try
            {
                ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new Uri("View/Pages/PostImage.xaml", UriKind.Relative));
            } catch
            {
                MessageBox.Show("Cannot locate PostImage.xaml");
            }
        }
        private void StartDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to DataBackup.xaml
            try
            {
                ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new Uri("View/Pages/DataBackup.xaml", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Cannot locate DataBackup.xaml");
            }
        }
        private void StartSeniorButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SeniorReview.xaml
            try
            {
                ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new Uri("View/Pages/SeniorReview.xaml", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Cannot locate SeniorReview.xaml");
            }
        }
    }

}
