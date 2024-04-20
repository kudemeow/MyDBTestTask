using System.Windows;
using testTaskDB.Model;

namespace testTaskDB
{
    /// <summary>
    /// Логика взаимодействия для CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        public CreateEmployee()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Surname.Text) && !string.IsNullOrWhiteSpace(Name.Text)
                && !string.IsNullOrWhiteSpace(FatherName.Text) && !string.IsNullOrWhiteSpace(Birthday.Text)
                && !string.IsNullOrWhiteSpace(SerPassport.Text) && !string.IsNullOrWhiteSpace(NumPassport.Text))
            {
                Employee employee = new Employee()
                {
                    Surname_Employee = Surname.Text,
                    Name_Employee = Name.Text,
                    FatherName_Employee = FatherName.Text,
                    Date_Of_Birth = Birthday.SelectedDate.Value,
                    Passport_Series = SerPassport.Text,
                    Passport_Number = NumPassport.Text
                };

                int countSurname = Surname.Text.Length;
                int countName = Name.Text.Length;
                int countFatherName = FatherName.Text.Length;
                int countSeries = SerPassport.Text.Length;
                int countNumber = NumPassport.Text.Length;

                if ((countSurname > 50) || (countName > 30) || (countFatherName > 50) || (Birthday.SelectedDate.Value > System.DateTime.Today)
                    || (countSeries > 4) || (countNumber > 6))
                {
                    MessageBox.Show("Максимальное количество символов для фамилии 50, для имени - 30, для отчества - 50, для серии паспорта - 4, для номера паспорта - 6. Дата рождения не может превышать текущую дату", "", MessageBoxButton.OK);
                }
                else
                {
                    MyDBEntities.GetContext().Employee.Add(employee);
                    MyDBEntities.GetContext().SaveChanges();

                    if (employee != null)
                    {
                        MessageBox.Show("Сотрудник успешно добавлен", "", MessageBoxButton.OK);
                    }
                }
            }
            else
                MessageBox.Show("Проверьте правильность ввода данных", "", MessageBoxButton.OK);
        }
    }
}
