using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Victim : ViewModelBase,IDataErrorInfo

    {

        private int emergencyID;
        public int EmergencyID
        {
            get { return emergencyID; }
            set { Set(nameof(EmergencyID), ref emergencyID, value); }
        }

        private int? perished;
        public int? Perished
        {
            get { return perished; }
            set { Set(nameof(Perished), ref perished, value); }
        }

        private int? injured;
        public int? Injured
        {
            get { return injured; }
            set { Set(nameof(Injured), ref injured, value); }
        }
        private int? evacuated;
        public int? Evacuated
        {
            get { return evacuated; }
            set { Set(nameof(Evacuated), ref evacuated, value); }
        }

        private int? rescued;
        public int? Rescued
        {
            get { return rescued; }
            set { Set(nameof(Rescued), ref rescued, value); }
        }

        private int? perishedChildren;
        public int? PerishedChildren
        {
            get { return perishedChildren; }
            set { Set(nameof(PerishedChildren), ref perishedChildren, value); }
        }

        private int? injuredChildren;
        public int? InjuredChildren
        {
            get { return injuredChildren; }
            set { Set(nameof(InjuredChildren), ref injuredChildren, value); }
        }
        private int? evacuatedChildren;
        public int? EvacuatedChildren
        {
            get { return evacuatedChildren; }
            set { Set(nameof(EvacuatedChildren), ref evacuatedChildren, value); }
        }

        private int? rescuedChildren;
        public int? RescuedChildren
        {
            get { return rescuedChildren; }
            set { Set(nameof(RescuedChildren), ref rescuedChildren, value); }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Perished":
                        {
                            if (Perished < 0)
                            {
                                error = "�� ������������� ��������";
                            }
                            if (Perished < PerishedChildren)
                            {
                                error = "����� �������� �� ������ ���� ������ ��� �����";
                            }

                                }

                        break;
                    case "PerishedChildren":
                        if (PerishedChildren < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Perished < PerishedChildren)
                        {
                            error = "����� �������� �� ������ ���� ������ ��� �����";
                        }

                        break;
                    case "Rescued":
                        if (Rescued < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Rescued < RescuedChildren)
                        {
                            error = "����� ��������� �� ������ ���� ������ ��� �����";
                        }

                        break;
                    case "Evacuated":
                        if (Evacuated < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Evacuated < EvacuatedChildren)
                        {
                            error = "����� �������������� �� ������ ���� ������ ��� �����";
                        }

                        break;
                    case "Injured":
                        if (Injured < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Injured < InjuredChildren)
                        {
                            error = "����� �������������� �� ������ ���� ������ ��� �����";
                        }

                        break;
                        
                    case "RescuedChildren":
                        if (RescuedChildren < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Rescued < RescuedChildren)
                        {
                            error = "����� ��������� �� ������ ���� ������ ��� �����";
                        }

                        break;
                    case "EvacuatedChildren":
                        if (EvacuatedChildren < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Evacuated < EvacuatedChildren)
                        {
                            error = "����� �������������� �� ������ ���� ������ ��� �����";
                        }
                        break;
                    case "InjuredChildren":
                        if (InjuredChildren < 0)
                        {
                            error = "�� ������������� ��������";
                        }
                        if (Injured < InjuredChildren)
                        {
                            error = "����� �������������� �� ������ ���� ������ ��� �����";
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
