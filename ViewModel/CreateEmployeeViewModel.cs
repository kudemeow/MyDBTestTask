using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTaskDB.Model;
using testTaskDB.View;

namespace testTaskDB.ViewModel
{
    internal class CreateEmployeeViewModel : ViewModelBase
    {
        readonly MyDBEntities myDB = new MyDBEntities();

        private string _surname;
        private string _name;
        private string _fathername;
        private string _brthday;
        private string _passportSeries;
        private string _passportNumber;

        //public ICommand ImportCSV { get; }
        //public ICommand ExportCSV { get; }
    }
}
