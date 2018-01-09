using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DutyOfficer:ViewModelBase
    {
        private int dutyOfficerID;
        private string nameDutyOfficer;
        private string positionDuty;

        private string loginDutyOfficer;

        private string passwordDutyOfficer;

        

        public int DutyOfficerID
        {
            get { return dutyOfficerID; }
            set { Set(nameof(DutyOfficerID), ref dutyOfficerID, value); }
        }
        public string NameDutyOfficer
        {
            get { return nameDutyOfficer; }
            set { Set(nameof(NameDutyOfficer), ref nameDutyOfficer, value); }
        }
        public string PositionDuty
        {
            get { return positionDuty; }
            set { Set(nameof(PositionDuty), ref positionDuty, value); }
        }
        public string LoginDutyOfficer
        {
            get { return loginDutyOfficer; }
            set { Set(nameof(LoginDutyOfficer), ref loginDutyOfficer, value); }
        }
        public string PasswordDutyOfficer
        {
            get { return passwordDutyOfficer; }
            set { Set(nameof(PasswordDutyOfficer), ref passwordDutyOfficer, value); }
        }
       
    }
}
