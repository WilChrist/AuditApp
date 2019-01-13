using ExcelleciaAuditApp.helper;
using modelFirst.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ExcelleciaAuditApp.userControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlHome.xaml
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Auditer" || propertyDescriptor.DisplayName == "Questions")
            {
                e.Cancel = true;
            }
        }

        private void DtgAudits_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new Audit();
            ((Audit)e.NewItem).Auditer = Session.CurrentAuditer;
            List<Question> questions = new List<Question>();
            foreach (var q in Session.AuditContext.Questions.Include("Audits").Include("Category").Include("Answers").ToList())
            {
                /*Question q1 = new Question();
                q1.Category = q.Category;
                q1.Audits = q.Audits;
                q1.Coefficient = q.Coefficient;
                q1.CreatedAt = q.CreatedAt;
                q1.Details = q.Details;
                q1.Id = q.Id;
                q1.Intitled = q.Intitled;
                q1.Answer = null;
                q1.Audits.Add((Audit)e.NewItem);
                questions.Add(q1);*/
                q.Audits.Add(((Audit)e.NewItem));
               // questions.Add(q.);
            }
            ((Audit)e.NewItem).Questions = new System.Collections.ObjectModel.ObservableCollection<Question>(questions);
        }
    }
}
