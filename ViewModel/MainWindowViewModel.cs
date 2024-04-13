using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using testTaskDB.Model;
using testTaskDB.View;

namespace testTaskDB.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public delegate void OpenHandler(object sender, RoutedEventArgs e);
        public event OpenHandler opened;
        public ICommand OpenCommand { get; }

        public MainWindowViewModel()
        {
            OpenCommand = new ViewModelCommand(ExecuteOpenCommand);
        }

        private void ExecuteOpenCommand(object obj)
        {
            opened();
        }
    }
}
