﻿using System;
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

namespace testTaskDB.View
{
    /// <summary>
    /// Логика взаимодействия для CreateOrganization.xaml
    /// </summary>
    public partial class CreateOrganizationView : Window
    {
        public CreateOrganizationView()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindowView mainWindowView = new MainWindowView();

            mainWindowView.Show();

            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
