using System.Windows;
using testTaskDB.View;
using testTaskDB.ViewModel;

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

            var context = new MainWindowViewModel();

            context.opened += OpenEvent;

            DataContext = context;
        }
        //Org, Emp
        public void OpenEvent(object sender, RoutedEventArgs e)
        {
            CreateOrganizationView createOrganizationView = new CreateOrganizationView();
            CreateEmployeeView createEmployeeView = new CreateEmployeeView();

            if (sender.Equals(Org))
            {
                createOrganizationView.Show();
            }
            else
            {
                createEmployeeView.Show();
            }

            Close();
        }
    }
}
