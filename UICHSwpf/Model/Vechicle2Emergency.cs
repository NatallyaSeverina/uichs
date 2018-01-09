using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vechicle2Emergency : ViewModelBase, IDataErrorInfo

    {

        private int vechicleID;
        public int VechicleID
        {
            get { return vechicleID; }
            set { Set(nameof(VechicleID), ref vechicleID, value); }
        }
        private string vechicleName;
        public string VechicleName
        {
            get { return vechicleName; }
            set { Set(nameof(VechicleName), ref vechicleName, value); }
        }

        private int emergencyID;
        public int EmergencyID
        {
            get { return emergencyID; }
            set { Set(nameof(EmergencyID), ref emergencyID, value); }
        }

        private int countVechicle;
        public int CountVechicle
        {
            get { return countVechicle; }
            set { Set(nameof(CountVechicle), ref countVechicle, value); }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "CountVechicle":
                        {
                            if (CountVechicle < 0)
                            {
                                error = "Не отрицательное значение";
                               
                            }
                            if (CountVechicle == 0)
                                error = "Введите количество";

                        }

                        break;
                    case "VechicleName":
                        {
                            if (String.IsNullOrEmpty(VechicleName))
                            {
                                error = "Обязательное поле";
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
