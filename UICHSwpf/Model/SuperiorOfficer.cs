using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SuperiorOfficer : ViewModelBase
    
    {
        
        private int emergencyID;
        public int EmergencyID
        {
            get { return emergencyID; }
            set { Set(nameof(EmergencyID), ref emergencyID, value); }
        }


        private string position;
        public string Position
        {
            get { return position; }
            set { Set(nameof(Position), ref position, value); }
        }
        private bool statusOfReport;
        public bool StatusOfReport
        {
            get { return  statusOfReport; }
            set { Set(nameof(StatusOfReport), ref statusOfReport, value); }
        }
        private TimeSpan? timeReport;
        public TimeSpan? TimeReport
        {
            get { return timeReport; }
            set { Set(nameof(TimeReport), ref timeReport, value); }
        }

    }
}
