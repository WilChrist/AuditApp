using ExcelleciaAuditApp.helper;
using MaterialDesignThemes.Wpf;
using modelFirst.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ExcelleciaAuditApp.userControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlCreate.xaml
    /// </summary>
    public partial class UserControlCreate : UserControl
    {
        private int i;
        private List<int> possibleScores;
        private Question question;
        Audit audit;
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
            possibleScores = new List<int>();
            for (int j = 0; j <= 10; j++)
            {
                possibleScores.Add(j);
            }
            cbxScores.ItemsSource = possibleScores;
            //cbxCategories.ItemsSource = Session.AuditContext.Categories.ToList();
            //cbxCategories.DisplayMemberPath = "Name";
        }


        private void CbxCategories_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cbxAudits.SelectedItem == null && i < 1)
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
            audit = new Audit();
            audit = (Audit)cbxAudits.SelectedItem;
            //Session.AuditContext.Entry(audit).Collection(a => a.Questions).Load();
            bdgReport.Badge = audit.Name;
            cbxCategories.ItemsSource = Session.AuditContext.Categories.Where(c => c.Questions.Any(q => q.Audits.Any(a => a.Id == audit.Id))).ToList();
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
            if (propertyDescriptor.DisplayName == "Audits" || propertyDescriptor.DisplayName == "Category" || propertyDescriptor.DisplayName == "Answers" || propertyDescriptor.DisplayName == "Recommandation")
            {
                e.Cancel = true;
            }
        }

        private void DtgQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            question = (Question)dtgQuestions.SelectedItem;
            if (question != null)
            {
                Answer answer = question.Answers.FirstOrDefault(a => a.Audit.Id == ((Audit)cbxAudits.SelectedItem).Id);
                if (answer == null)
                {
                    answer = new Answer
                    {
                        Audit = (Audit)cbxAudits.SelectedItem
                    };
                    question.Answers.Add(answer);
                }

                answer.RecommandationToApply = question.Recommandation;
                answer.RiskIncurred = question.Risk;
                mbxAnswer.DataContext = question;
                stkpAnswer.DataContext = answer;
                dlhHost2.ShowDialog(mbxAnswer);
            }

            //MessageBox.Show("Please Choose an audit first", App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonSaveAnswer_Click(object sender, RoutedEventArgs e)
        {
            SnackbarTwo.MessageQueue.Enqueue("Anwser well Saved");
            SnackbarTwo.IsActive = true;
            Session.Save();


        }

        private void ButtonGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (cbxAudits.SelectedItem == null && i < 1)
            {
                //MessageBox.Show("Please Choose an audit first", App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
                dlgHost1.ShowDialog(mbx);

                cbxAudits.Focus();
                i++;
            }
            else
            {
                audit = (Audit)cbxAudits.SelectedItem;
                
            }
        }
    }
}
