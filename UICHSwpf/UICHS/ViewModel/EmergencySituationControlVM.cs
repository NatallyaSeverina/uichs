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
    public class EmergencySituationControlVM : ViewModelBase
    {
        Model.IEmergencySituationRepositiry emergencySituationRepositiry;
        Model.IVechicleRepository vechicleRepository;
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
        public RelayCommand  SelectionRegionCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand AddRowCommand { get; set; }
        public RelayCommand DeleteRowCommand { get; set; }
        public RelayCommand CheckedSuperiorOfficerCommand { get; set; }
        public RelayCommand UnCheckedSuperiorOfficerCommand { get; set; }
        public RelayCommand AddSpecialReportCommand { get; set; }
        public RelayCommand OpenSpecialReportCommand { get; set; }
       
        public RelayCommand UnLoadedCommand { get; set; }
        public RelayCommand DeleteSpecialReportCommand { get; set; }
        public EmergencySituationControlVM(Model.IEmergencySituationRepositiry _emergencySituationRepositiry, Model.IVechicleRepository _vechicleRepository)
        {
            
            emergencySituationRepositiry = _emergencySituationRepositiry;
                vechicleRepository = _vechicleRepository;
                Model.Vechicle2Emergency vechicleToEmergency = new Model.Vechicle2Emergency();
                Messenger.Default.Register<Model.DutyOfficer>(this, HandleDutyOfficer);
                Messenger.Default.Register<DateTime>(this, HandleDate);
                NeighborhoodList = new ObservableCollection<string>();
                Vechicle2Emergency = new ObservableCollection<Model.Vechicle2Emergency>();
                CurrentVechicle2Emergency = new Model.Vechicle2Emergency();
                EmergencySituation = new Model.EmergencySituation();
                Victim = new Model.Victim();
               ReceivedMessage = new Model.ReceivedMessage();
                IsButtonDeleteReportEnable = false;
                IsButtonMinusEnable = false;
                PathSpecialReport = "Ссылка на документ отсутствует";
                string time = DateTime.Now.ToString("HH:mm:ss");
                ReceivedMessage.TimeOfReceive = new TimeSpan(int.Parse(time.Split(':')[0]),    // hours
                               int.Parse(time.Split(':')[1]), int.Parse(time.Split(':')[2]));
                SuperiorOfficers = new ObservableCollection<Model.SuperiorOfficer>() { new Model.SuperiorOfficer() { Position = "Министр по ЧС", StatusOfReport=false },
                new Model.SuperiorOfficer() { Position = "1-й заместитель Министра", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Заместитель Министра (куратор службы)", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Заместитель Министра (куратор тыла)", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Заместитель Министра (куратор кадров)", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Ответственный по МЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Начальник УАССиЛЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Начальник РЦУРЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "1-й заместитель начальника РЦУРЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Начальник ОУСиС РЦУРЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Дежурная часть МЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Пресс-секретарь МЧС", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Совет Министров", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Администрация Президента", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Служба безопасности Президента", StatusOfReport = false },
                new Model.SuperiorOfficer() { Position = "Гос. секретариат Сов.Без.", StatusOfReport = false } };
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
                     
                      EmergencySituation.EditLog = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToString("HH:mm:ss")} зарегистрировал {DutyOfficer.NameDutyOfficer}";

                          emergencySituationRepositiry.AddNewEmergency(EmergencySituation, SuperiorOfficers, Vechicle2Emergency, ReceivedMessage, Victim, DutyOfficer);

                          DialogWindowVM.CloseDialogWindow();
                      }
                      catch (Exception)
                      {
                          MyMessageBox _myMessageBox = new MyMessageBox();
                          Messenger.Default.Send("Данные о технике,\nвведеные некорректно,\nне сохранены");
                          _myMessageBox.Show();
                          DialogWindowVM.CloseDialogWindow();

                      }


                  });
                UnLoadedCommand = new RelayCommand(() =>
                  {
                      ViewModelLocator.Cleanup();
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
                            // MessageBox.Show("Данный файл уже открыт");

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
        private void HandleDate(DateTime d)
        {
           SelectedDate = d;
           EmergencySituation.DateOfEmergency = SelectedDate;

        }
        //private void Prc_Exited(object sender, EventArgs e)
        //{

        //    File.Delete(PathSpecialReport);
        //}

    }

}

