using System.Linq;
using System.Windows;
using testTaskDB.Model;

namespace testTaskDB
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
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            Close();
        }
    }
}
