using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vechicle : ViewModelBase

    {

       private int vechicleID;
        public int VechicleID
        {
            get { return vechicleID; }
            set { Set(nameof(VechicleID), ref vechicleID, value); }
        }

        private string nameVechicle;
        public string NameVechicle
        {
            get { return nameVechicle; }
            set { Set(nameof(NameVechicle), ref nameVechicle, value); }
        }

    }
}
