using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using testTaskDB.Model;

namespace testTaskDB
{
    /// <summary>
    /// Логика взаимодействия для OutputEmployeeAndOrganization.xaml
    /// </summary>
    public partial class OutputEmployeeAndOrganization : Window
    {
        public string FilePath { get; set; }
        public OutputEmployeeAndOrganization()
        {
            InitializeComponent();

            OrgTable.DataContext = MyDBEntities.GetContext().Organization.ToList();
            EmpTable.DataContext = MyDBEntities.GetContext().Employee.ToList();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            Close();
        }

        private void ImportOrg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
                FilePath = openFileDialog.FileName;
            else
                MessageBox.Show("Ошибка чтения файла");

            OrgTable.DataContext = ReadFileOrganization(FilePath);
        }

        private void ExportOrg_Click(object sender, RoutedEventArgs e)
        {
            List<Organization> organizations = (List<Organization>)OrgTable.ItemsSource;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                CSVLibraryAK.CSVLibraryAK.Export(saveFileDialog.FileName, ToDataTable(organizations));

                if (File.Exists(saveFileDialog.FileName))
                    MessageBox.Show("Файл успешно экспортирован");
            }
            else
                MessageBox.Show("Ошибка загрузки файла");
        }

        private void ImportEmp_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
                FilePath = openFileDialog.FileName;
            else
                MessageBox.Show("Ошибка чтения файла");

            EmpTable.DataContext = ReadFileEmployee(FilePath);
        }

        private void ExportEmp_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> employees = (List<Employee>)EmpTable.ItemsSource;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                CSVLibraryAK.CSVLibraryAK.Export(saveFileDialog.FileName, ToDataTable(employees));

                if (File.Exists(saveFileDialog.FileName))
                    MessageBox.Show("Файл успешно экспортирован");
            }
            else
                MessageBox.Show("Ошибка загрузки файла");
        }

        public static List<Organization> ReadFileOrganization(string filepath)
        {
            var lines = File.ReadAllLines(filepath, Encoding.GetEncoding(1251));

            var dataOrg = from l in lines.Skip(1)
                       let split = l.Split(';')
                       select new Organization
                       {
                           Id_Organization = int.Parse(split[0]),
                           Name_Organization = split[1],
                           ITN_Organization = split[2],
                           Legal_Address = split[3],
                           Actual_Address = split[4]
                       };

            return dataOrg.ToList();
        }
        public static List<Employee> ReadFileEmployee(string filepath)
        {
            var lines = File.ReadAllLines(filepath, Encoding.GetEncoding(1251));

            var dataOrg = from l in lines.Skip(1)
                          let split = l.Split(';')
                          select new Employee
                          {
                              Id_Employee = int.Parse(split[0]),
                              Surname_Employee = split[1],
                              Name_Employee = split[2],
                              FatherName_Employee = split[3],
                              Date_Of_Birth = DateTime.Parse(split[4]),
                              Passport_Series = split[5],
                              Passport_Number = split[6]
                          };

            return dataOrg.ToList();
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void OrgTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void EmpTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
