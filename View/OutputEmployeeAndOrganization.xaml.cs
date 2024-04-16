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
using System.Windows.Shapes;
using testTaskDB.Model;

namespace testTaskDB.View
{
    /// <summary>
    /// Логика взаимодействия для OutputEmployeeAndOrganization.xaml
    /// </summary>
    public partial class OutputEmployeeAndOrganization : Window
    {
        public OutputEmployeeAndOrganization()
        {
            InitializeComponent();

            MyDBEntities db = new MyDBEntities();
            
            OrgTable.ItemsSource = db.Organization.ToList();
            EmpTable.ItemsSource = db.Employee.ToList();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindowView mainWindowView = new MainWindowView();

            mainWindowView.Show();

            Close();
        }
    }
}
