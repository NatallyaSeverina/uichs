using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Report : ViewModelBase

    {

        private DateTime dateOfReport;
        public DateTime DateOfReport
        {
            get { return dateOfReport; }
            set { Set(nameof(DateOfReport), ref dateOfReport, value); }
        }

        private byte[] report1;
        public byte[] Report1
        {
            get { return report1; }
            set { Set(nameof(Report1), ref report1, value); }
        }
    }
}
