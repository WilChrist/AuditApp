using ExcelleciaAuditApp.helper;
using modelFirst;
using modelFirst.Model;
using System;
using System.Linq;
using System.Windows;

namespace ExcelleciaAuditApp
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            Session.CurrentAuditer = new modelFirst.Model.Auditer();
            Session.LoginAttemptCount = 0;
            Session.AuditContext = new AuditContext();

            Auditer auditer = Session.AuditContext.Auditers.FirstOrDefault();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Session.LoginAttemptCount++;

            string email = "";
            string password = "";

            email = txtboxEmail.Text;
            password = pwdboxPassword.Password;
            //password = BCrypt.Net.BCrypt.HashPassword(password);

            Console.WriteLine($"{email} + {password}");

            
                Auditer auditer = Session.AuditContext.Auditers.Include("Audits.Questions.Answers").FirstOrDefault(a => a.Email.Equals(email));
                if (auditer != null && BCrypt.Net.BCrypt.Verify(password, auditer.Password, false, BCrypt.Net.HashType.SHA256))
                {
                    Session.CurrentAuditer = auditer;
                    Window mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    txtblocError.Text = "Login and Password Incorrect, Try Again";
                }

            if (Session.LoginAttemptCount >= 3)
            {
                MessageBox.Show("Login Attempt OverFlow, Please contact your manager", App.AppName, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                App.Current.Shutdown();
            }
        }
    }
}
