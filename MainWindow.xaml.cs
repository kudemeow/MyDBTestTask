using System.Windows;
using testTaskDB;

namespace testTaskDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Org_Click(object sender, RoutedEventArgs e)
        {
            CreateOrganization createOrganization = new CreateOrganization();

            createOrganization.Show();

            Close();
        }

        private void Emp_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee createEmployee = new CreateEmployee();

            createEmployee.Show();

            Close();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            OutputEmployeeAndOrganization outputEmployeeAndOrganization = new OutputEmployeeAndOrganization();

            outputEmployeeAndOrganization.Show();

            Close();
        }
    }
}
