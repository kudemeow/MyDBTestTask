using System.Windows;
using testTaskDB.Model;

namespace testTaskDB
{
    /// <summary>
    /// Логика взаимодействия для CreateOrganization.xaml
    /// </summary>
    public partial class CreateOrganization: Window
    {
        public CreateOrganization()
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
            if (!string.IsNullOrWhiteSpace(NameOrg.Text) && !string.IsNullOrWhiteSpace(ITNOrg.Text)
                && !string.IsNullOrWhiteSpace(LegalAddressOrg.Text) && !string.IsNullOrWhiteSpace(ActualAddressOrg.Text))
            {
                Organization organization = new Organization()
                {
                    Name_Organization = NameOrg.Text,
                    ITN_Organization = ITNOrg.Text,
                    Legal_Address = LegalAddressOrg.Text,
                    Actual_Address = ActualAddressOrg.Text
                };

                int countName = NameOrg.Text.Length;
                int countITN = ITNOrg.Text.Length;
                int countFirstAddress = LegalAddressOrg.Text.Length;
                int countSecondAddress = ActualAddressOrg.Text.Length;

                if ((countName > 255) || (countITN > 12) || (countFirstAddress > 255) || (countSecondAddress > 255))
                {
                    MessageBox.Show("Максимальное количество символов для названия 255, для ИНН - 12 и адреса - 255", "", MessageBoxButton.OK);
                }
                else
                {
                    DB.db.Organization.Add(organization);
                    DB.db.SaveChanges();

                    if (organization != null)
                    {
                        MessageBox.Show("Организщация успешно добавлена", "", MessageBoxButton.OK);
                    }


                }
            }
            else
                MessageBox.Show("Проверьте правильность ввода данных", "", MessageBoxButton.OK);
        }
    }
}
