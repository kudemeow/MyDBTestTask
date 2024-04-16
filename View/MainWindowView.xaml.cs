using System.Windows;
using testTaskDB.View;

namespace testTaskDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void Org_Click(object sender, RoutedEventArgs e)
        {
            CreateOrganizationView createOrganizationView = new CreateOrganizationView();

            createOrganizationView.Show();

            Close();
        }

        private void Emp_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeView createEmployeeView = new CreateEmployeeView();

            createEmployeeView.Show();

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
