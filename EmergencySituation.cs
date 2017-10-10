using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class EmergencySituation : ViewModelBase, IDataErrorInfo
    {
        private int emergencyID;
        public int EmergencyID
        {
            get { return emergencyID; }
            set { Set(nameof(EmergencyID), ref emergencyID, value); }
        }
        private DateTime dateOfEmergency;
        public DateTime DateOfEmergency
        {
            get { return dateOfEmergency; }
            set { Set(nameof(DateOfEmergency), ref dateOfEmergency, value); }
        }
        private int? perished;
        public int? Perished
        {
            get { return perished; }
            set { Set(nameof(Perished), ref perished, value); }
        }
        private string region;
        public string Region
        {
            get { return region; }
            set { Set(nameof(Region), ref region, value); }
        }
        private int? perishedChildren;
        public int? PerishedChildren
        {
            get { return perishedChildren; }
            set { Set(nameof(PerishedChildren), ref perishedChildren, value); }
        }
        private string neighborhood;
        public string Neighborhood
        {
            get { return neighborhood; }
            set { Set(nameof(Neighborhood), ref neighborhood, value); }
        }

        private string popylatedLocality;
        public string PopylatedLocality
        {
            get { return popylatedLocality; }
            set { Set(nameof(PopylatedLocality), ref popylatedLocality, value); }
        }

        private string adress;
        public string Adress
        {
            get { return adress; }
            set { Set(nameof(Adress), ref adress, value); }
        }

        private string kind;
        public string Kind
        {
            get { return kind; }
            set { Set(nameof(Kind), ref kind, value); }
        }

        private TimeSpan? checkOutTime;
        public TimeSpan? CheckOutTime
        {
            get { return checkOutTime; }
            set { Set(nameof(CheckOutTime), ref checkOutTime, value); }
        }
        private TimeSpan? registrationTime;
        public TimeSpan? RegistrationTime
        {
            get { return registrationTime; }
            set { Set(nameof(RegistrationTime), ref registrationTime, value); }
        }
        private TimeSpan? arrivalTime;
        public TimeSpan? ArrivalTime
        {
            get { return arrivalTime; }
            set { Set(nameof(ArrivalTime), ref arrivalTime, value); }
        }
        private string descriptionOfEmergency;
        public string DescriptionOfEmergency
        {
            get { return descriptionOfEmergency; }
            set { Set(nameof(DescriptionOfEmergency), ref descriptionOfEmergency, value); }
        }

        private TimeSpan? timeLocalisation;
        public TimeSpan? TimeLocalisation
        {
            get { return timeLocalisation; }
            set { Set(nameof(TimeLocalisation), ref timeLocalisation, value); }
        }

        private TimeSpan? timeLiquidation;
        public TimeSpan? TimeLiquidation
        {
            get { return timeLiquidation; }
            set { Set(nameof(TimeLiquidation), ref timeLiquidation, value); }
        }


        private bool toRegistration;
        public bool ToRegistration
        {
            get { return toRegistration; }
            set { Set(nameof(ToRegistration), ref toRegistration, value); }
        }

        private bool toReport;
        public bool ToReport
        {
            get { return toReport; }
            set { Set(nameof(ToReport), ref toReport, value); }
        }

        private string problematicIssues;
        public string ProblematicIssues
        {
            get { return problematicIssues; }
            set { Set(nameof(ProblematicIssues), ref problematicIssues, value); }
        }


        private byte[] specialReport;
        public byte[] SpecialReport
        {
            get { return specialReport; }
            set { Set(nameof(SpecialReport), ref specialReport, value); }
        }

        private string extraReportSuperiorOfficer;
        public string ExtraReportSuperiorOfficer
        {
            get { return extraReportSuperiorOfficer; }
            set { Set(nameof(ExtraReportSuperiorOfficer), ref extraReportSuperiorOfficer, value); }
        }

        private string editLog;
        public string EditLog
        {
            get { return editLog; }
            set { Set(nameof(EditLog), ref editLog, value); }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "DescriptionOfEmergency":
                        {
                            if (String.IsNullOrEmpty(DescriptionOfEmergency))
                            {
                                error = "Обязательное поле";
                            }
                           
                        }

                        break;
                    case "TimeLiquidation":
                        {
                            if (TimeLiquidation >=new TimeSpan(0, 23, 59, 59)|| TimeLiquidation <= new TimeSpan(0, 0, 0, 0))
                            {
                                error = "Недопустимое значение";
                            }

                        }

                        break;
                    case "CheckOutTime":
                        {
                            if (CheckOutTime >= new TimeSpan(0, 23, 59, 59) || CheckOutTime <= new TimeSpan(0, 0, 0, 0))
                            {
                                error = "Недопустимое значение";
                            }

                        }

                        break;
                    case "ArrivalTime":
                        {
                            if (ArrivalTime >= new TimeSpan(0, 23, 59, 59) || ArrivalTime <= new TimeSpan(0, 0, 0, 0))
                            {
                                error = "Недопустимое значение";
                            }

                        }

                        break;
                    case "TimeLocalisation":
                        {
                            if (TimeLocalisation >= new TimeSpan(0, 23, 59, 59) || TimeLocalisation <= new TimeSpan(0, 0, 0, 0))
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
