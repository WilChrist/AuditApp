using ExcelleciaAuditApp.userControls;
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
using ExcelleciaAuditApp.helper;

namespace ExcelleciaAuditApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl uscDashboard = null;
        UserControl uscAudit = null;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            Session.AuditContext.Entry(Session.CurrentAuditer).Collection(a => a.Audits).Load();
            this.DataContext = Session.CurrentAuditer;

            uscDashboard = new UserControlHome();
            uscAudit = new UserControlCreate();

            GridMain.Children.Add(uscDashboard);
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    GridMain.Children.Add(uscDashboard);
                    break;
                case "ItemCreate":
                    GridMain.Children.Add(uscAudit);
                    break;
                default:
                    MessageBox.Show("This Feature is not yes developped, please wait untill the next release or contact me at willynzesseu@gmail.com", App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Session.Save();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Session.AuditContext.Dispose();
            Session.CurrentAuditer = new modelFirst.Model.Auditer();
            Window login = new Login();
            login.Show();
            Close();
        }
    }
}
