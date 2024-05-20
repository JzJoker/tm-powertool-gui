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
using WUApiLib;

namespace tm_powertool_gui.View.UserControls.PostImage
{
    /// <summary>
    /// Interaction logic for WindowsUpdate.xaml
    /// </summary>
    public partial class WindowsUpdate : UserControl
    {
        private UpdateSession updateSession;
        private UpdateSearcher updateSearcher;
        private ISearchResult searchResult;
        public WindowsUpdate()
        {
            InitializeComponent();
            InitializeComponent();
            updateSession = new UpdateSession();
            updateSearcher = (UpdateSearcher)updateSession.CreateUpdateSearcher();
        }
        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            CheckButton.IsEnabled = false;
            UpdatesListBox.Items.Clear();
            RunButton.IsEnabled = false;

            searchResult = await Task.Run(() => updateSearcher.Search("IsInstalled=0 AND Type='Software'"));

            foreach (IUpdate update in searchResult.Updates)
            {
                Dispatcher.Invoke(() => UpdatesListBox.Items.Add(update.Title));
            }

            RunButton.IsEnabled = true;
            CheckButton.IsEnabled = true;
        }

        private async void RunButton_Click(object sender, RoutedEventArgs e)
        {
            RunButton.IsEnabled = false;
            ProgressBar.Value = 0;

            UpdateCollection updatesToInstall = new UpdateCollection();
            foreach (IUpdate update in searchResult.Updates)
            {
                updatesToInstall.Add(update);
            }

            IUpdateInstaller installer = updateSession.CreateUpdateInstaller();
            installer.Updates = updatesToInstall;

            await Task.Run(() =>
            {
                IInstallationResult result = installer.Install();
                Dispatcher.Invoke(() => ProgressBar.Value = 100); // Update progress bar on UI thread
            });

            RunButton.IsEnabled = true;
        }
    }
}
