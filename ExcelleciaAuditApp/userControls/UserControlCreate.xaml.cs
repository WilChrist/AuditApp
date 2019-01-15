using ExcelleciaAuditApp.helper;
using HandlingPdf.pdf;
using MaterialDesignThemes.Wpf;
using modelFirst.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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
        Audit audit;
        Question question;
        PdfGenerator generator;

        public UserControlCreate()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            SnackbarOne.IsActive = false;
            cbxAudits.ItemsSource = Session.CurrentAuditer.Audits.ToList();
            cbxAudits.DisplayMemberPath = "Name";
            i = 0;
            possibleScores = new List<int>();
            for (int j = 0; j <= 10; j++)
            {
                possibleScores.Add(j);
            }
            cbxScores.ItemsSource = possibleScores;

            generator = new PdfGenerator();
            mbxAnswer.DataContext = new Question();
            stkpAnswer.DataContext = new Answer();
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

            audit = new Audit();
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
            if (propertyDescriptor.DisplayName == "Audits" || propertyDescriptor.DisplayName == "Category" || propertyDescriptor.DisplayName == "Answers" || propertyDescriptor.DisplayName == "Risk" || propertyDescriptor.DisplayName == "Details" || propertyDescriptor.DisplayName == "Scale")
            {
                e.Cancel = true;
            }
        }

        private void DtgQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Console.WriteLine("****************************************************");

            //mbxAnswer.DataContext = new Question();
            //stkpAnswer.DataContext = new Answer();
            if (!dlhHost2.IsVisible)
            {
                question = new Question();
                question = (Question)dtgQuestions.SelectedItem;
                if (question != null)
                {
                    Answer answer = question.Answers.FirstOrDefault(a => a.Audit.Id == ((Audit)cbxAudits.SelectedItem).Id);
                    if (answer == null)
                    {
                        answer = new Answer
                        {
                            Reply = null
                        };
                        answer.Audit = (Audit)cbxAudits.SelectedItem;
                        question.Answers.Add(answer);
                    }

                    if (String.IsNullOrEmpty(answer.RecommandationToApply))
                    {
                        answer.RecommandationToApply = question.Recommandation;
                    }
                    
                    //answer.RiskIncurred = question.Risk;
                    mbxAnswer.DataContext = question;
                    stkpAnswer.DataContext = answer;

                    dlhHost2.Visibility = Visibility.Visible;
                    dlhHost2.ShowDialog(mbxAnswer);
                }
                
            
            }else
                {
                    //Console.WriteLine("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnn");
                    SnackbarTwo.MessageQueue.Enqueue("Please save this answer FIRST!");
                }

            //MessageBox.Show("Please Choose an audit first", App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonSaveAnswer_Click(object sender, RoutedEventArgs e)
        {
            dlhHost2.Visibility = Visibility.Hidden;
            EnqueueThisMessageInSnackbarTwo("Anwser well Saved");
            Session.Save();


        }

        private void EnqueueThisMessageInSnackbarTwo(String message)
        {
            SnackbarTwo.MessageQueue.Enqueue(message);
            SnackbarTwo.IsActive = true;
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



                //mettre le chemin (défaut c:\)
                generator.OuthPutPath = ".\\Rapport_" + audit.Name + ".pdf";
                //nom de l'auditeur
                generator.EmployeeName = Session.CurrentAuditer.FirstName + " " + Session.CurrentAuditer.LastName;
                //nom de l'entreprise auditée
                generator.CompanyName = audit.AuditedCompanyName;
                UnHideProgressBar();
                dlgHost3.ShowDialog(mbxProgress);

                //générer l'audit par id
                Task.Delay(TimeSpan.FromSeconds(2))
                .ContinueWith((t, _) => generator.generateReport(audit.Id), null,
                    TaskScheduler.FromCurrentSynchronizationContext());

                Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t, _) => HideProgressBar(), null,
                    TaskScheduler.FromCurrentSynchronizationContext());


            }
        }

        private void UnHideProgressBar()
        {
            pgrbReport.IsIndeterminate = true;
            pgrbReport.Value = 33;

            dlgHost3.Visibility = Visibility.Visible;
            mbxProgress.Visibility = Visibility.Visible;
        }

        private void HideProgressBar()
        {
            pgrbReport.IsIndeterminate = false;
            pgrbReport.Value = 100;
            
            dlgHost3.IsOpen = false;
            EnqueueThisMessageInSnackbarTwo("Rapport_" + audit.Name + " Well Generated");
        }
    }
}
