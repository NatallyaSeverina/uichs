using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReceivedMessage: ViewModelBase, IDataErrorInfo
    {

        private int emergencyID;
        public int EmergencyID
        {
            get { return emergencyID; }
            set { Set(nameof(EmergencyID), ref emergencyID, value); }
        }

        private TimeSpan? timeMessageInROCHS;
        public TimeSpan? TimeMessageInROCHS
        {
            get { return timeMessageInROCHS; }
            set { Set(nameof(TimeMessageInROCHS), ref timeMessageInROCHS, value); }
        }

        private TimeSpan timeOfReceive;
        public TimeSpan TimeOfReceive
        {
            get { return timeOfReceive; }
            set { Set(nameof(TimeOfReceive), ref timeOfReceive, value); }
        }

        private int dutyOfficerID;
        public int DutyOfficerID
        {
            get { return dutyOfficerID; }
            set { Set(nameof(DutyOfficerID), ref dutyOfficerID, value); }
        }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                   
                    case "TimeMessageInROCHS":
                        {
                            if (TimeMessageInROCHS >= new TimeSpan(0, 23, 59, 59) || TimeMessageInROCHS <= new TimeSpan(0, 0, 0, 0))
                            {
                                error = "Недопустимое значение";
                            }

                        }

                        break;

                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
