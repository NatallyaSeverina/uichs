using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UICHS.ViewModel
{
    public class EditEmergencySituationControlVM : ViewModelBase
    {
        private string checkString;
        Model.IEmergencySituationRepositiry emergencySituationRepositiry;
        Model.IDutyOfficerRepository dutyOfficerRepository;
        Model.IVechicleRepository vechicleRepository;
        
        private int emergencyID;
        public int EmergencyID
        {
            get { return emergencyID; }
            set { Set(nameof(EmergencyID), ref emergencyID, value); }
        }
        private DateTime selectedDate = DateTime.Now.Date;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { Set(nameof(SelectedDate), ref selectedDate, value); }
        }
        private bool isButtonMinusEnable;
        public bool IsButtonMinusEnable
        {
            get { return isButtonMinusEnable; }
            set { Set(nameof(IsButtonMinusEnable), ref isButtonMinusEnable, value); }
        }
       
        private bool isButtonDeleteReportEnable;
        public bool IsButtonDeleteReportEnable
        {
            get { return isButtonDeleteReportEnable; }
            set { Set(nameof(IsButtonDeleteReportEnable), ref isButtonDeleteReportEnable, value); }
        }
        private string nameOfDutyOfficer;
        public string NameOfDutyOfficer
        {
            get { return nameOfDutyOfficer; }
            set { Set(nameof(NameOfDutyOfficer), ref nameOfDutyOfficer, value); }
        }
        
        private string pathSpecialReport;
        public string PathSpecialReport
        {
            get { return pathSpecialReport; }
            set { Set(nameof(pathSpecialReport), ref pathSpecialReport, value); }
        }
        private Model.SuperiorOfficer currentSuperiorOfficer;
        public Model.SuperiorOfficer CurrentSuperiorOfficer
        {
            get { return currentSuperiorOfficer; }
            set { Set(nameof(CurrentSuperiorOfficer), ref currentSuperiorOfficer, value); }
        }
        private Model.DutyOfficer dutyOfficer;
        public Model.DutyOfficer DutyOfficer
        {
            get { return dutyOfficer; }
            set { Set(nameof(DutyOfficer), ref dutyOfficer, value); }
        }
        private Model.EmergencySituation emergencySituation;
        public Model.EmergencySituation EmergencySituation
        {
            get { return emergencySituation; }
            set { Set(nameof(EmergencySituation), ref emergencySituation, value); }
        }
        
        private Model.ReceivedMessage receivedMessage;
        public Model.ReceivedMessage ReceivedMessage
        {
            get { return receivedMessage; }
            set { Set(nameof(ReceivedMessage), ref receivedMessage, value); }
        }
        
        private Model.Victim victim;
        public Model.Victim Victim
        {
            get { return victim; }
            set { Set(nameof(Victim), ref victim, value); }
        }
        private Model.Vechicle2Emergency currentVechicle2Emergency;
        public Model.Vechicle2Emergency CurrentVechicle2Emergency
        {
            get { return currentVechicle2Emergency; }
            set { Set(nameof(CurrentVechicle2Emergency), ref currentVechicle2Emergency, value); }
        }
        public List<string> RegionList { get; set; }
        public ObservableCollection<string> NameVechicleList { get; set; }
        public List<string> KindEmergencyList { get; set; }
        public ObservableCollection<string> NeighborhoodList { get; set; }
       
        public ObservableCollection<Model.Vechicle2Emergency> Vechicle2Emergency { get; set; }
        
        public ObservableCollection<Model.SuperiorOfficer> SuperiorOfficers { get; set; }
        public RelayCommand UnLoadedCommand { get; set; }
        public RelayCommand SelectionRegionCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand AddRowCommand { get; set; }
        public RelayCommand DeleteRowCommand { get; set; }
        public RelayCommand CheckedSuperiorOfficerCommand { get; set; }
        public RelayCommand UnCheckedSuperiorOfficerCommand { get; set; }
        public RelayCommand AddSpecialReportCommand { get; set; }
        public RelayCommand OpenSpecialReportCommand { get; set; }
       
        public RelayCommand DeleteSpecialReportCommand { get; set; }
        public EditEmergencySituationControlVM(Model.IEmergencySituationRepositiry _emergencySituationRepositiry,
            Model.IDutyOfficerRepository _dutyOfficerRepository, Model.IVechicleRepository _vechicleRepository)
        {
            
            vechicleRepository = _vechicleRepository;
            emergencySituationRepositiry = _emergencySituationRepositiry;
            dutyOfficerRepository = _dutyOfficerRepository;
            Messenger.Default.Register<Model.DutyOfficer>(this, HandleDutyOfficer);
            Messenger.Default.Register<int>(this, HandleEmergencyID);
            Vechicle2Emergency = new ObservableCollection<Model.Vechicle2Emergency>();
            SuperiorOfficers = new ObservableCollection<Model.SuperiorOfficer>();
            
            NeighborhoodList = new ObservableCollection<string>();
            FillOutNeighborhoodList();
           
            CurrentVechicle2Emergency = new Model.Vechicle2Emergency();
            RegionList = new List<string> { "Брестская область", "Витебская область", "Гомельская область", "Гродненская область", "Минская область", "Могилевская область", "г.Минск" };
            KindEmergencyList = new List<string> { "Загорание частного жилого дома",
                "Загорание частного нежилого дома",
                "Загорание дачного дома",
            "Загорание бытовок,вагончиков",
                "Загорание в гараже",
                "Загорание в квартире",
                "Загорание в административном здании",
                "Загорание на промышленном предприятии",
                "Загорание частного жилого дома",
            "Загорание на железнодорожном транспорте",
                "Загорание в сельскохозяйственной отрасли","Загорание в учреждении образования",
            "Загорание в гостиницах, общежитиях",
                "Загорание автомобиля",
                "Загорание леса, травы и кустарников",
                "Загорание торфяника",
                "Загорание полигона ТБО",
                "Взрыв","Обрушение",
            "ДТП",
                "Авария ЖКХ",
                "Происшествие по ЛС",
                "Прочее" };
           


            SelectionRegionCommand = new RelayCommand(() =>
            {
                switch (EmergencySituation.Region)
                {
                    case "Брестская область":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Барановичский район");
                            NeighborhoodList.Add("Берёзовский район");
                            NeighborhoodList.Add("Брестский район");
                            NeighborhoodList.Add("Ганцевичский район");
                            NeighborhoodList.Add("Дрогичинский район");
                            NeighborhoodList.Add("Жабинковский район");
                            NeighborhoodList.Add("Ивановский район");
                            NeighborhoodList.Add("Ивацевичский район");
                            NeighborhoodList.Add("Каменецкий район");
                            NeighborhoodList.Add("Кобринский район");
                            NeighborhoodList.Add("Лунинецкий район");
                            NeighborhoodList.Add("Ляховичский район");
                            NeighborhoodList.Add("Малоритский район");
                            NeighborhoodList.Add("Пинский район");
                            NeighborhoodList.Add("Пружанский район");
                            NeighborhoodList.Add("Столинский район");
                            NeighborhoodList.Add("г.Брест");
                        }
                        break;
                    case "Витебская область":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Бешенковичский район");
                            NeighborhoodList.Add("Браславский район");
                            NeighborhoodList.Add("Верхнедвинский район");
                            NeighborhoodList.Add("Витебский район");
                            NeighborhoodList.Add("Глубокский район");
                            NeighborhoodList.Add("Городокский район");
                            NeighborhoodList.Add("Докшицкий район");
                            NeighborhoodList.Add("Дубровенский район");
                            NeighborhoodList.Add("Лепельский район");
                            NeighborhoodList.Add("Лиозненский район");
                            NeighborhoodList.Add("Миорский район");
                            NeighborhoodList.Add("Оршанский район");
                            NeighborhoodList.Add("Полоцкий район");
                            NeighborhoodList.Add("Поставский район");
                            NeighborhoodList.Add("Россонский район");
                            NeighborhoodList.Add("Сенненский район");
                            NeighborhoodList.Add("Толочинский район");
                            NeighborhoodList.Add("Ушачский район");
                            NeighborhoodList.Add("Чашникский район");
                            NeighborhoodList.Add("Шарковщинский район");
                            NeighborhoodList.Add("Шумилинский район");
                            NeighborhoodList.Add("г.Витебск");

                        }
                        break;
                    case "Гомельская область":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Брагинский район");
                            NeighborhoodList.Add("Буда-Кошелевский район");
                            NeighborhoodList.Add("Ветковский район");
                            NeighborhoodList.Add("Гомельский район");
                            NeighborhoodList.Add("Добрушский район");
                            NeighborhoodList.Add("Ельский район");
                            NeighborhoodList.Add("Житковичский район");
                            NeighborhoodList.Add("Жлобинский район");
                            NeighborhoodList.Add("Калинковичский район");
                            NeighborhoodList.Add("Кормянский район");
                            NeighborhoodList.Add("Лельчицкий район");
                            NeighborhoodList.Add("Лоевский район");
                            NeighborhoodList.Add("Мозырский район");
                            NeighborhoodList.Add("Наровлянский район");
                            NeighborhoodList.Add("Октябрьский район");
                            NeighborhoodList.Add("Петриковский район");
                            NeighborhoodList.Add("Речицкий район");
                            NeighborhoodList.Add("Рогачевский район");
                            NeighborhoodList.Add("Светлогорский район");
                            NeighborhoodList.Add("Хойникский район");
                            NeighborhoodList.Add("Чечерский район");
                            NeighborhoodList.Add("г.Гомель");
                        }
                        break;
                    case "Гродненская область":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Берестовицкий район");
                            NeighborhoodList.Add("Волковысский район");
                            NeighborhoodList.Add("Вороновский район");
                            NeighborhoodList.Add("Гродненский район");
                            NeighborhoodList.Add("Дятловский район");
                            NeighborhoodList.Add("Зельвенский район");
                            NeighborhoodList.Add("Ивьевский район");
                            NeighborhoodList.Add("Кореличский район");
                            NeighborhoodList.Add("Лидский район");
                            NeighborhoodList.Add("Мостовский район");
                            NeighborhoodList.Add("Новогрудский район");
                            NeighborhoodList.Add("Островецкий район");
                            NeighborhoodList.Add("Ошмянский район");
                            NeighborhoodList.Add("Свислочский район");
                            NeighborhoodList.Add("Слонимский район");
                            NeighborhoodList.Add("Сморгонский район");
                            NeighborhoodList.Add("Щучинский район");
                            NeighborhoodList.Add("г.Гродно");

                        }
                        break;
                    case "Минская область":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Березинский район");
                            NeighborhoodList.Add("Борисовский район");
                            NeighborhoodList.Add("Вилейский район");
                            NeighborhoodList.Add("Воложинский район");
                            NeighborhoodList.Add("Дзержинский район");
                            NeighborhoodList.Add("Клецкий район");
                            NeighborhoodList.Add("Копыльский район");
                            NeighborhoodList.Add("Крупский район");
                            NeighborhoodList.Add("Логойский район");
                            NeighborhoodList.Add("Любанский район");
                            NeighborhoodList.Add("Минский район");
                            NeighborhoodList.Add("Молодечненский район");
                            NeighborhoodList.Add("Мядельский район");
                            NeighborhoodList.Add("Несвижский район");
                            NeighborhoodList.Add("Пуховичский район");
                            NeighborhoodList.Add("Слуцкий район");
                            NeighborhoodList.Add("Смолевичский район");
                            NeighborhoodList.Add("Солигорский район");
                            NeighborhoodList.Add("Стародорожский район");
                            NeighborhoodList.Add("Столбцовский район");
                            NeighborhoodList.Add("Узденский район");
                            NeighborhoodList.Add("Червенский район");

                        }
                        break;
                    case "Могилевская область":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Белыничский район");
                            NeighborhoodList.Add("Бобруйский район");
                            NeighborhoodList.Add("Быховский район");
                            NeighborhoodList.Add("Глусский район");
                            NeighborhoodList.Add("Горецкий район");
                            NeighborhoodList.Add("Дрибинский район");
                            NeighborhoodList.Add("Кировский район");
                            NeighborhoodList.Add("Климовичский район");
                            NeighborhoodList.Add("Кличевский район");
                            NeighborhoodList.Add("Костюковичский район");
                            NeighborhoodList.Add("Краснопольский район");
                            NeighborhoodList.Add("Кричевский район");
                            NeighborhoodList.Add("Круглянский район");
                            NeighborhoodList.Add("Могилевский район");
                            NeighborhoodList.Add("Мстиславский район");
                            NeighborhoodList.Add("Осиповичский район");
                            NeighborhoodList.Add("Славгородский район");
                            NeighborhoodList.Add("Хотимский район");
                            NeighborhoodList.Add("Чаусский район");
                            NeighborhoodList.Add("Чериковский район");
                            NeighborhoodList.Add("Шкловский район");
                            NeighborhoodList.Add("г.Могилев");

                        }
                        break;
                    case "г.Минск":
                        {
                            NeighborhoodList.Clear();
                            NeighborhoodList.Add("Заводской район");
                            NeighborhoodList.Add("Ленинский район");
                            NeighborhoodList.Add("Московский район");
                            NeighborhoodList.Add("Октябрьский район");
                            NeighborhoodList.Add("Партизанский район");
                            NeighborhoodList.Add("Первомайский район");
                            NeighborhoodList.Add("Советский район");
                            NeighborhoodList.Add("Фрунзенский район");
                            NeighborhoodList.Add("Центральный район");

                        }
                        break;
                }

            });
            SaveCommand = new RelayCommand(() =>
            {

                
                try
                {
                   
                   MyMessageBox _myMessageBox = new MyMessageBox();
                 
                    if(checkString!=FillCheckStringFromDB(EmergencyID))
                    {
                        Messenger.Default.Send("Информация о ЧС была обновлена.\nОткройте заново для редактирования\nактуальных сведений.");
                        _myMessageBox.Show();
                    }

                    else
                    {

                        EmergencySituation.EditLog += $"\n {DateTime.Now.ToShortDateString()} {DateTime.Now.ToString("HH:mm:ss")} редактировал {DutyOfficer.NameDutyOfficer}";
                        emergencySituationRepositiry.EditEmergency(EmergencySituation, SuperiorOfficers, Vechicle2Emergency, ReceivedMessage, Victim);
                        DialogWindowVM.CloseDialogWindow();
                    }
                   
                    
                }
                catch (Exception)
                {
                    MyMessageBox _myMessageBox = new MyMessageBox();
                    Messenger.Default.Send("Проверьте правильность \nвведенных данных");
                    _myMessageBox.Show();
                    
                }


            });
            CancelCommand = new RelayCommand(() =>
            {

                DialogWindowVM.CloseWindow();
            });
            AddRowCommand = new RelayCommand(() =>
            {
                Vechicle2Emergency.Add(new Model.Vechicle2Emergency());
                IsButtonMinusEnable = true;
            });
            AddSpecialReportCommand = new RelayCommand(() =>
            {
                OpenFileDialog saveFileDialog = new OpenFileDialog();
                saveFileDialog.Filter = "Text files (*.doc,*.docx)|*.doc;*.docx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    PathSpecialReport = Path.GetFileName(saveFileDialog.FileName);
                    IsButtonDeleteReportEnable = true;
                    EmergencySituation.SpecialReport = File.ReadAllBytes(saveFileDialog.FileName);
                }

            });
          
            DeleteRowCommand = new RelayCommand(() =>
            {
                Vechicle2Emergency.Remove(CurrentVechicle2Emergency);
                if (Vechicle2Emergency.Count == 0) IsButtonMinusEnable = false;
            });
            CheckedSuperiorOfficerCommand = new RelayCommand(() =>
            {
                CurrentSuperiorOfficer.StatusOfReport = true;
                string timeReport = DateTime.Now.ToString("HH:mm:ss");
                CurrentSuperiorOfficer.TimeReport = new TimeSpan(int.Parse(timeReport.Split(':')[0]),    // hours
                           int.Parse(timeReport.Split(':')[1]), int.Parse(timeReport.Split(':')[2]));
            });
            UnCheckedSuperiorOfficerCommand = new RelayCommand(() =>
            {
                CurrentSuperiorOfficer.StatusOfReport = false;
                CurrentSuperiorOfficer.TimeReport = null;
            });
            UnLoadedCommand = new RelayCommand(() =>
            {
                ViewModelLocator.Cleanup();
            });
            OpenSpecialReportCommand = new RelayCommand(() =>
            {
                if (PathSpecialReport != "Ссылка на документ отсутствует")
                {

                    string fileName = PathSpecialReport;
                    var bytes = EmergencySituation.SpecialReport;
                    try
                    {
                        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            foreach (var b in bytes)
                                fs.WriteByte(b);
                        }
                        Process prc = new Process();
                        prc.StartInfo.FileName = fileName;
                        //prc.EnableRaisingEvents = true;
                        //prc.Exited += Prc_Exited;
                        prc.Start();
                    }
                    catch (Exception)
                    {
                        MyMessageBox _myMessageBox = new MyMessageBox();
                        Messenger.Default.Send("Данный файл уже открыт");
                        _myMessageBox.Show();
                       

                    }
                }

            });
            DeleteSpecialReportCommand = new RelayCommand(() =>
            {
                PathSpecialReport = "Ссылка на документ отсутствует";
                IsButtonDeleteReportEnable = false;
                EmergencySituation.SpecialReport = null;

            });
           
        }
       
        private void HandleDutyOfficer(Model.DutyOfficer d)
        {
            DutyOfficer = d;

        }
        private void HandleEmergencyID (int _id)
        {
            EmergencyID = _id;
            EmergencySituation = emergencySituationRepositiry.GetEmergencySituationByID(EmergencyID);
            
            Victim = emergencySituationRepositiry.GetVictimByID(EmergencyID);
            
            ReceivedMessage = emergencySituationRepositiry.GetReceivedMessageByID(EmergencyID);
            
            foreach (var s in emergencySituationRepositiry.GetSuperiorOfficerByEmergencyID(EmergencyID))
            {
                SuperiorOfficers.Add(s);
                

            }
            foreach (var v in emergencySituationRepositiry.GetVechicle2EmergencyByEmergencyID(EmergencyID))
            {

                v.VechicleName = vechicleRepository.GetNameByID(v.VechicleID);

                Vechicle2Emergency.Add(v);
                
            }
            if (Vechicle2Emergency.Count != 0) { IsButtonMinusEnable = true; }
            NameOfDutyOfficer = dutyOfficerRepository.GetByEmerencyID(EmergencySituation.EmergencyID);
            if (EmergencySituation.SpecialReport == null)
            {
                PathSpecialReport = PathSpecialReport = "Ссылка на документ отсутствует";
                IsButtonDeleteReportEnable = false;
            }
            else
            {
                PathSpecialReport = $"Специальное донесение {EmergencySituation.Region.ToString()} {ReceivedMessage.TimeOfReceive.Hours}-{ReceivedMessage.TimeOfReceive.Minutes} " +
                    $"{EmergencySituation.DateOfEmergency.Date.ToShortDateString()}.doc";
                IsButtonDeleteReportEnable = true;
            }
            checkString = FillCheckStringFromDB(EmergencyID);


        }
        private string FillCheckStringFromDB(int _id)
        {
            string str="";
            Model.EmergencySituation checkEmergencySituation = emergencySituationRepositiry.GetEmergencySituationByID(_id);
            if(checkEmergencySituation.Adress!=null)
           str += $"{checkEmergencySituation.Adress.ToString()}";
            str += $"{checkEmergencySituation.DescriptionOfEmergency.ToString()}";
            if (checkEmergencySituation.ArrivalTime != null)
                str += $"{checkEmergencySituation.ArrivalTime.ToString()}";
            if (checkEmergencySituation.CheckOutTime != null)
                str += $"{checkEmergencySituation.DateOfEmergency.ToString()}";
            if (checkEmergencySituation.CheckOutTime != null)
                str += $"{checkEmergencySituation.DateOfEmergency.ToString()}";
           
            if (checkEmergencySituation.EditLog != null)
                str += $"{checkEmergencySituation.EditLog.ToString()}";
            if (checkEmergencySituation.ExtraReportSuperiorOfficer != null)
                str += $"{checkEmergencySituation.ExtraReportSuperiorOfficer.ToString()}";
            if (checkEmergencySituation.Kind != null)
                str += $"{checkEmergencySituation.Kind.ToString()}";
            if (checkEmergencySituation.Neighborhood != null)
                str += $"{checkEmergencySituation.Neighborhood.ToString()}";
            if (checkEmergencySituation.PopylatedLocality != null)
                str += $"{checkEmergencySituation.PopylatedLocality.ToString()}";
            if (checkEmergencySituation.ProblematicIssues != null)
                str += $"{checkEmergencySituation.ProblematicIssues.ToString()}";
            if (checkEmergencySituation.Region != null)
                str += $"{checkEmergencySituation.Region.ToString()}";
            if (checkEmergencySituation.SpecialReport != null)
                str += $"{checkEmergencySituation.SpecialReport.ToString()}";
            if (checkEmergencySituation.TimeLiquidation != null)
                str += $"{checkEmergencySituation.TimeLiquidation.ToString()}";
            if (checkEmergencySituation.TimeLocalisation != null)
                str += $"{checkEmergencySituation.TimeLocalisation.ToString()}";
            
                str += $"{checkEmergencySituation.ToRegistration.ToString()}";
           
                str += $"{checkEmergencySituation.ToReport.ToString()}";
            Model.Victim checkVictim = emergencySituationRepositiry.GetVictimByID(_id);
            if (checkVictim != null)
            {
                if(checkVictim.Perished!=null)
                str += $"{checkVictim.Perished.ToString()}";
                if (checkVictim.PerishedChildren != null)
                    str += $"{checkVictim.PerishedChildren.ToString()}";
                if (checkVictim.Evacuated != null)
                    str += $"{checkVictim.Evacuated.ToString()}";
                if (checkVictim.EvacuatedChildren != null)
                    str += $"{checkVictim.EvacuatedChildren.ToString()}";
                if (checkVictim.Injured != null)
                    str += $"{checkVictim.Injured.ToString()}";
                if (checkVictim.InjuredChildren != null)
                    str += $"{checkVictim.InjuredChildren.ToString()}";
                if (checkVictim.Rescued != null)
                    str += $"{checkVictim.Rescued.ToString()}";
                if (checkVictim.RescuedChildren != null)
                    str += $"{checkVictim.RescuedChildren.ToString()}";
            }
            
           Model.ReceivedMessage checkReceivedMessage = emergencySituationRepositiry.GetReceivedMessageByID(EmergencyID);
            if (checkReceivedMessage.TimeMessageInROCHS != null)
                str += $"{checkReceivedMessage.TimeMessageInROCHS.ToString()}";
            if (checkReceivedMessage.TimeOfReceive != null)
                str += $"{checkReceivedMessage.TimeOfReceive.ToString()}";
            str+=  $"{checkReceivedMessage.DutyOfficerID.ToString()}";
       
            foreach (var s in emergencySituationRepositiry.GetSuperiorOfficerByEmergencyID(EmergencyID))
            {
                str += $"{s.Position}" +
                    $"{s.StatusOfReport.ToString()}";
                if(s.TimeReport!=null)
                    str+=$"{s.TimeReport.ToString()}";

            }
            foreach (var v in emergencySituationRepositiry.GetVechicle2EmergencyByEmergencyID(EmergencyID))
            {
                str += $"{v.VechicleID.ToString()}" +
                    $"{v.CountVechicle.ToString()}";
            }
           
            return str;
        }
        private void FillOutNeighborhoodList()
        {

            NeighborhoodList.Add("Барановичский район");
            NeighborhoodList.Add("Берёзовский район");
            NeighborhoodList.Add("Брестский район");
            NeighborhoodList.Add("Ганцевичский район");
            NeighborhoodList.Add("Дрогичинский район");
            NeighborhoodList.Add("Жабинковский район");
            NeighborhoodList.Add("Ивановский район");
            NeighborhoodList.Add("Ивацевичский район");
            NeighborhoodList.Add("Каменецкий район");
            NeighborhoodList.Add("Кобринский район");
            NeighborhoodList.Add("Лунинецкий район");
            NeighborhoodList.Add("Ляховичский район");
            NeighborhoodList.Add("Малоритский район");
            NeighborhoodList.Add("Пинский район");
            NeighborhoodList.Add("Пружанский район");
            NeighborhoodList.Add("Столинский район");
            NeighborhoodList.Add("г.Брест");
            NeighborhoodList.Add("Бешенковичский район");
            NeighborhoodList.Add("Браславский район");
            NeighborhoodList.Add("Верхнедвинский район");
            NeighborhoodList.Add("Витебский район");
            NeighborhoodList.Add("Глубокский район");
            NeighborhoodList.Add("Городокский район");
            NeighborhoodList.Add("Докшицкий район");
            NeighborhoodList.Add("Дубровенский район");
            NeighborhoodList.Add("Лепельский район");
            NeighborhoodList.Add("Лиозненский район");
            NeighborhoodList.Add("Миорский район");
            NeighborhoodList.Add("Оршанский район");
            NeighborhoodList.Add("Полоцкий район");
            NeighborhoodList.Add("Поставский район");
            NeighborhoodList.Add("Россонский район");
            NeighborhoodList.Add("Сенненский район");
            NeighborhoodList.Add("Толочинский район");
            NeighborhoodList.Add("Ушачский район");
            NeighborhoodList.Add("Чашникский район");
            NeighborhoodList.Add("Шарковщинский район");
            NeighborhoodList.Add("Шумилинский район");
            NeighborhoodList.Add("г.Витебск");

            NeighborhoodList.Add("Брагинский район");
            NeighborhoodList.Add("Буда-Кошелевский район");
            NeighborhoodList.Add("Ветковский район");
            NeighborhoodList.Add("Гомельский район");
            NeighborhoodList.Add("Добрушский район");
            NeighborhoodList.Add("Ельский район");
            NeighborhoodList.Add("Житковичский район");
            NeighborhoodList.Add("Жлобинский район");
            NeighborhoodList.Add("Калинковичский район");
            NeighborhoodList.Add("Кормянский район");
            NeighborhoodList.Add("Лельчицкий район");
            NeighborhoodList.Add("Лоевский район");
            NeighborhoodList.Add("Мозырский район");
            NeighborhoodList.Add("Наровлянский район");
            NeighborhoodList.Add("Октябрьский район");
            NeighborhoodList.Add("Петриковский район");
            NeighborhoodList.Add("Речицкий район");
            NeighborhoodList.Add("Рогачевский район");
            NeighborhoodList.Add("Светлогорский район");
            NeighborhoodList.Add("Хойникский район");
            NeighborhoodList.Add("Чечерский район");
            NeighborhoodList.Add("г.Гомель");

            NeighborhoodList.Add("Берестовицкий район");
            NeighborhoodList.Add("Волковысский район");
            NeighborhoodList.Add("Вороновский район");
            NeighborhoodList.Add("Гродненский район");
            NeighborhoodList.Add("Дятловский район");
            NeighborhoodList.Add("Зельвенский район");
            NeighborhoodList.Add("Ивьевский район");
            NeighborhoodList.Add("Кореличский район");
            NeighborhoodList.Add("Лидский район");
            NeighborhoodList.Add("Мостовский район");
            NeighborhoodList.Add("Новогрудский район");
            NeighborhoodList.Add("Островецкий район");
            NeighborhoodList.Add("Ошмянский район");
            NeighborhoodList.Add("Свислочский район");
            NeighborhoodList.Add("Слонимский район");
            NeighborhoodList.Add("Сморгонский район");
            NeighborhoodList.Add("Щучинский район");
            NeighborhoodList.Add("г.Гродно");


            NeighborhoodList.Add("Березинский район");
            NeighborhoodList.Add("Борисовский район");
            NeighborhoodList.Add("Вилейский район");
            NeighborhoodList.Add("Воложинский район");
            NeighborhoodList.Add("Дзержинский район");
            NeighborhoodList.Add("Клецкий район");
            NeighborhoodList.Add("Копыльский район");
            NeighborhoodList.Add("Крупский район");
            NeighborhoodList.Add("Логойский район");
            NeighborhoodList.Add("Любанский район");
            NeighborhoodList.Add("Минский район");
            NeighborhoodList.Add("Молодечненский район");
            NeighborhoodList.Add("Мядельский район");
            NeighborhoodList.Add("Несвижский район");
            NeighborhoodList.Add("Пуховичский район");
            NeighborhoodList.Add("Слуцкий район");
            NeighborhoodList.Add("Смолевичский район");
            NeighborhoodList.Add("Солигорский район");
            NeighborhoodList.Add("Стародорожский район");
            NeighborhoodList.Add("Столбцовский район");
            NeighborhoodList.Add("Узденский район");
            NeighborhoodList.Add("Червенский район");


            NeighborhoodList.Add("Белыничский район");
            NeighborhoodList.Add("Бобруйский район");
            NeighborhoodList.Add("Быховский район");
            NeighborhoodList.Add("Глусский район");
            NeighborhoodList.Add("Горецкий район");
            NeighborhoodList.Add("Дрибинский район");
            NeighborhoodList.Add("Кировский район");
            NeighborhoodList.Add("Климовичский район");
            NeighborhoodList.Add("Кличевский район");
            NeighborhoodList.Add("Костюковичский район");
            NeighborhoodList.Add("Краснопольский район");
            NeighborhoodList.Add("Кричевский район");
            NeighborhoodList.Add("Круглянский район");
            NeighborhoodList.Add("Могилевский район");
            NeighborhoodList.Add("Мстиславский район");
            NeighborhoodList.Add("Осиповичский район");
            NeighborhoodList.Add("Славгородский район");
            NeighborhoodList.Add("Хотимский район");
            NeighborhoodList.Add("Чаусский район");
            NeighborhoodList.Add("Чериковский район");
            NeighborhoodList.Add("Шкловский район");
            NeighborhoodList.Add("г.Могилев");


            NeighborhoodList.Add("Заводской район");
            NeighborhoodList.Add("Ленинский район");
            NeighborhoodList.Add("Московский район");
            NeighborhoodList.Add("Октябрьский район");
            NeighborhoodList.Add("Партизанский район");
            NeighborhoodList.Add("Первомайский район");
            NeighborhoodList.Add("Советский район");
            NeighborhoodList.Add("Фрунзенский район");
            NeighborhoodList.Add("Центральный район");


        }

    }
}
