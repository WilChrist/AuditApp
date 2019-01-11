using ExcelleciaAuditApp.helper;
using MaterialDesignThemes.Wpf;
using modelFirst.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ExcelleciaAuditApp.userControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlCreate.xaml
    /// </summary>
    public partial class UserControlCreate : UserControl
    {
        int i;
        public UserControlCreate()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            SnackbarOne.IsActive = false;
            cbxAudits.ItemsSource = Session.CurrentAuditer.Audits;
            cbxAudits.DisplayMemberPath = "Name";
            i = 0;
            //cbxCategories.ItemsSource = Session.AuditContext.Categories.ToList();
            //cbxCategories.DisplayMemberPath = "Name";
        }
        
        
        private void CbxCategories_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cbxAudits.SelectedItem == null && i<1)
            {
                //MessageBox.Show("Please Choose an audit first", App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
                dlgHost1.ShowDialog(mbx);

                cbxAudits.Focus();
                i++;
            }
        }

        private void CbxCategories_LostFocus(object sender, RoutedEventArgs e)
        {
            i = 0;
        }

        private void CbxAudits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Audit audit = new Audit();
            audit = (Audit)cbxAudits.SelectedItem;
            //Session.AuditContext.Entry(audit).Collection(a => a.Questions).Load();

            cbxCategories.ItemsSource =  Session.AuditContext.Categories.Where(c=>c.Questions.Any(q=>q.Audits.Any(a=>a.Id==audit.Id))).ToList();
            cbxCategories.DisplayMemberPath = "Name";
            SnackbarOne.IsActive = true;
            
        }

        private void CbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SnackbarOne.IsActive = false;

            SnackbarTwo.MessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
            SnackbarTwo.MessageQueue.Enqueue("Loading Questions...");
            SnackbarTwo.IsActive = true;

            Audit audit = new Audit();
            audit = (Audit)cbxAudits.SelectedItem;
           // Session.AuditContext.Entry(audit).Collection(a => a.Questions).Load();

            Category category = new Category();
            category = (Category)cbxCategories.SelectedItem;

            dtgQuestions.ItemsSource = audit.Questions.Where(q => q.Category.Id == category.Id);
            dtgQuestions.BringIntoView();
        }

        private void DtgQuestions_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            e.Column.MinWidth = 100;
            if (propertyDescriptor.DisplayName == "Audits" || propertyDescriptor.DisplayName == "Category" || propertyDescriptor.DisplayName == "Answer" || propertyDescriptor.DisplayName == "Recommandation")
            {
                e.Cancel = true;
            }
        }

        private void DtgQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mbxAnswer.DataContext = (Question) dtgQuestions.SelectedItem;
            dlhHost2.ShowDialog(mbxAnswer);
            //MessageBox.Show("Please Choose an audit first", App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
