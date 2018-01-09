using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UICHS.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string pathReport;
        DispatcherTimer timer;
        Model.IReportRepository reportRepository;
        Model.IEmergencySituationRepositiry emergencySituationRepositiry;
        private string statusBarInfo;
        public string StatusBarInfo
        {
            get { return statusBarInfo; }
            set { Set(nameof(StatusBarInfo), ref statusBarInfo, value); }
        }
        private string time;
        public string Time
        {
            get { return time; }
            set { Set(nameof(Time), ref time, value); }
        }
        private DateTime selectedDate = DateTime.Now.Date;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { Set(nameof(SelectedDate), ref selectedDate, value); }
        }
        private Model.DutyOfficer currentDutyOfficer;
        public Model.DutyOfficer CurrentDutyOfficer
        {
            get { return currentDutyOfficer; }
            set { Set(nameof(CurrentDutyOfficer), ref currentDutyOfficer, value); }
        }
        private Model.EmergencySituation currentEmergency;
        public Model.EmergencySituation CurrentEmergency
        {
            get { return currentEmergency; }
            set { Set(nameof(CurrentEmergency), ref currentEmergency, value); }
        }
        private Model.Report report;
        public Model.Report Report
        {
            get { return report; }
            set { Set(nameof(Report), ref report, value); }
        }
        private bool isAddReportEnable;
        public bool IsAddReportEnable
        {
            get { return isAddReportEnable; }
            set { Set(nameof(IsAddReportEnable), ref isAddReportEnable, value); }
        }
        private bool isDeleteReportEnable;
        public bool IsDeleteReportEnable
        {
            get { return isDeleteReportEnable; }
            set { Set(nameof(IsDeleteReportEnable), ref isDeleteReportEnable, value); }
        }
        private bool isEditEmergencyEnable;
        public bool IsEditEmergencyEnable
        {
            get { return isEditEmergencyEnable; }
            set { Set(nameof(IsEditEmergencyEnable), ref isEditEmergencyEnable, value); }
        }
        public ObservableCollection<KeyValuePair<string, int>> ValueKey { set; get; }
        public ObservableCollection<KeyValuePair<string, int>> EmergenciesInfoByRegionList { set; get; }
        public ObservableCollection <Model.EmergencySituation> EmergencySituations { set; get; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public RelayCommand ChangeUserCommand  { get; set; }
        public RelayCommand UserSettingCommand { get; set; }
        public RelayCommand AddEmergencyCommand { get; set; }
        public RelayCommand AddReportCommand { get; set; }
        public RelayCommand OpenReportCommand { get; set; }
        public RelayCommand DeleteReportCommand { get; set; }
        public RelayCommand SelectedDateCommand { get; set; }
        public RelayCommand  SelectionChangedDataGridCommand { get; set; }
        public RelayCommand EditEmergencyCommand { get; set; }
        public RelayCommand DeleteEmergencyCommand { get; set; }
        public RelayCommand AboutProgrammCommand { get; set; }
        public RelayCommand UnLoadedCommand { get; set; }
        public RelayCommand WriteXMLDocCommand { get; set; }
        public RelayCommand ReadXMLDocCommand { get; set; }
      
        private Model.IDutyOfficerRepository dutyOfficerRepository;
        public MainViewModel(Model.IDutyOfficerRepository _dutyOfficerRepository, Model.IReportRepository _reportRepository,Model.IEmergencySituationRepositiry _emergencySituationRepositiry)
        {
            int i = 0;
           
            emergencySituationRepositiry = _emergencySituationRepositiry;
            ValueKey = new ObservableCollection<KeyValuePair<string, int>>();
            EmergencySituations = new ObservableCollection<Model.EmergencySituation>();
            EmergenciesInfoByRegionList = new ObservableCollection<KeyValuePair<string, int>>();
            FillOutEmergencySituationsCollection();
            FillOutEmergenciesInfoByRegionList();
            FillOutStatusBarInfo();
            
            reportRepository = _reportRepository;
            IsEditEmergencyEnable = false;
            if ((Report = reportRepository.GetByDate(selectedDate)) != null)
            {
                IsAddReportEnable = false;
                IsDeleteReportEnable = true;
            }
            else
            {
                IsAddReportEnable = true;
                IsDeleteReportEnable = false;
            }
            
            Messenger.Default.Register<Model.DutyOfficer>(this, HandleDutyOfficer);
            dutyOfficerRepository = _dutyOfficerRepository;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1.0);
            Task taskShowTime = new Task(
                    () =>
                    {
                      timer.Start();
                      timer.Tick += (s,e)=>
                      {
                          i++;
                          if(i%180==0)//каждые 3 минуты обновляются данные из бд
                          {
                              EmergencySituations.Clear();
                              FillOutEmergencySituationsCollection();
                          }
                        DateTime datetime = DateTime.Now;
                        Time= datetime.ToString("HH:mm:ss");
                      };  
                    });
            taskShowTime.Start();
            ChangeUserCommand = new RelayCommand(() =>
              {
                  AuthenticationControl _authenticationControl = new AuthenticationControl();
                  DialogWindow _dialogWindow = new DialogWindow(_authenticationControl);
                  foreach (Window window in Application.Current.Windows)
                  {
                      if ((window as MainWindow) != null) window.Close();
                  }
                  _dialogWindow.Show();
              });
           UserSettingCommand = new RelayCommand(() =>
            {
                UserSettingControl _userSettingControl = new UserSettingControl();
                DialogWindow _dialogWindow = new DialogWindow(_userSettingControl);
                Messenger.Default.Send(CurrentDutyOfficer);
                _dialogWindow.ShowDialog();
            });
            AddEmergencyCommand = new RelayCommand(() =>
            {
                EmergencySituationControl _emergencySituationControl = new EmergencySituationControl();
                DialogWindow _dialogWindow = new DialogWindow(_emergencySituationControl);
                Messenger.Default.Send(CurrentDutyOfficer);
                Messenger.Default.Send(SelectedDate);
                if ((_dialogWindow.ShowDialog()) == true)
                {
                    EmergencySituations.Clear();
                    FillOutEmergencySituationsCollection();
                }
               
                    
            });
            EditEmergencyCommand= new RelayCommand(() =>
            {
                EditEmergencySituationControl _editEmergencySituationControl = new EditEmergencySituationControl();
                DialogWindow _dialogWindow = new DialogWindow(_editEmergencySituationControl);
                Messenger.Default.Send(CurrentDutyOfficer);
                Messenger.Default.Send(CurrentEmergency.EmergencyID);
                if ((_dialogWindow.ShowDialog()) == true)
                {
                    EmergencySituations.Clear();
                    FillOutEmergencySituationsCollection();
                }


            });
            AddReportCommand = new RelayCommand(() =>
            {
                OpenFileDialog saveFileDialog = new OpenFileDialog();
                saveFileDialog.Filter = "Text files (*.doc,*.docx)|*.doc;*.docx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    pathReport = Path.GetFileName(saveFileDialog.FileName);
                    Report = new Model.Report();
                    Report.Report1 = File.ReadAllBytes(saveFileDialog.FileName);
                    Report.DateOfReport = SelectedDate;
                    reportRepository.AddReport(Report);
                    IsAddReportEnable = false;
                    IsDeleteReportEnable = true;
                }

            });
            OpenReportCommand = new RelayCommand(() =>
              {
                  pathReport = $"Сводка за {selectedDate.Date.ToShortDateString()} сутки.doc";
                  
                  var bytes = Report.Report1;
                  try
                  {
                      using (FileStream fs = new FileStream(pathReport, FileMode.Create, FileAccess.Write, FileShare.None))
                  {
                      foreach (var b in bytes)
                          fs.WriteByte(b);
                  }
                  Process prc = new Process();
                  prc.StartInfo.FileName = pathReport;
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
                  
              });
            ReadXMLDocCommand = new RelayCommand(() =>
                {
                    StreamWriter fs = new StreamWriter("XML документ.txt", false, Encoding.GetEncoding(1251));
                    fs.Write(emergencySituationRepositiry.ReadXMLDoc());
                Process prc = new Process();
                prc.StartInfo.FileName = "XML документ.txt";
                prc.Start();
            });
            DeleteReportCommand = new RelayCommand(() =>
              {
                  reportRepository.DeleteReport(SelectedDate);
                  IsAddReportEnable = true;
                  IsDeleteReportEnable = false;
              });
            SelectedDateCommand = new RelayCommand(() =>
              {
                  if ((Report = reportRepository.GetByDate(SelectedDate)) != null)
                  {
                      IsAddReportEnable = false;
                      IsDeleteReportEnable = true;
                  }
                  else
                  {
                      IsAddReportEnable = true;
                      IsDeleteReportEnable = false;
                  }
                  EmergencySituations.Clear();
                  FillOutEmergencySituationsCollection();
              });
            SelectionChangedDataGridCommand = new RelayCommand(() =>
            {
                if (CurrentEmergency == null)
                {
                   
                    IsEditEmergencyEnable = false;
                }
                else
                {
                    
                    IsEditEmergencyEnable = true;
                }
            });
            UnLoadedCommand = new RelayCommand(() =>
            {
               
             string[] docList = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.doc");
            foreach (var f in docList)
            {
                try
                {

                    File.Delete(f);
                }
                catch (IOException)
                {
                    continue;
                }
            }
                ViewModelLocator.Cleanup();

            });
            DeleteEmergencyCommand = new RelayCommand(() =>
              {
                  emergencySituationRepositiry.DeleteEmergencySituation(CurrentEmergency.EmergencyID);
                  EmergencySituations.Clear();
                  FillOutEmergencySituationsCollection();
              });
           AboutProgrammCommand = new RelayCommand(() =>
            {
                MyMessageBox _myMessageBox = new MyMessageBox();
                Messenger.Default.Send($"Программное средство \nУчет оперативной информации \nо чрезвычайных ситуациях.\nАвтор Северина Н.И.");
                _myMessageBox.Show();
               
            });
            WriteXMLDocCommand = new RelayCommand(() =>
            {
                emergencySituationRepositiry.WriteXMLDoc();
                MyMessageBox _myMessageBox = new MyMessageBox();
                Messenger.Default.Send($"Информация о ЧС записана в\nEmergencySituations.xml документ");
                _myMessageBox.Show();
            });
           
            

        }

      

        private void HandleDutyOfficer(Model.DutyOfficer d)
        {
            CurrentDutyOfficer = d;
            
        }
        private void FillOutEmergencySituationsCollection()
        {
            Task task = new Task(
                    () =>
                    {
                        foreach (var em in emergencySituationRepositiry.GetEmergencyByDate(SelectedDate))
                        {
                            em.Perished = emergencySituationRepositiry.GetPerishedByID(em.EmergencyID);
                            em.PerishedChildren = emergencySituationRepositiry.GetPerishedChildrenByID(em.EmergencyID);

                            DispatcherHelper.CheckBeginInvokeOnUI(
                                 () =>
                                 {
                                     EmergencySituations.Add(em);
                                 });

                          
                        }
                        DispatcherHelper.CheckBeginInvokeOnUI(
                                 () =>
                                 {
                                     FillOutValueKeyCollection();
                                     FillOutEmergenciesInfoByRegionList();
                                     FillOutStatusBarInfo();
                                 });
                        
                    });
            task.Start();
           
            
            
        }
        private void FillOutValueKeyCollection()
        {
            ValueKey.Clear();
            ValueKey.Add(new KeyValuePair<string, int>("Брестская область", GetNumberOfEmergencyPerDay("Брестская область")));
            ValueKey.Add(new KeyValuePair<string, int>("Витебская область", GetNumberOfEmergencyPerDay("Витебская область")));
            ValueKey.Add(new KeyValuePair<string, int>("Гомельская область", GetNumberOfEmergencyPerDay("Гомельская область")));
            ValueKey.Add(new KeyValuePair<string, int>("Гродненская область", GetNumberOfEmergencyPerDay("Гродненская область")));
            ValueKey.Add(new KeyValuePair<string, int>("Минская область", GetNumberOfEmergencyPerDay("Минская область")));
            ValueKey.Add(new KeyValuePair<string, int>("Могилевская область", GetNumberOfEmergencyPerDay("Могилевская область")));
            ValueKey.Add(new KeyValuePair<string, int>("г.Минск", GetNumberOfEmergencyPerDay("г.Минск")));
        }
        private void FillOutEmergenciesInfoByRegionList()
        {
            EmergenciesInfoByRegionList.Clear();
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("Брестская область", emergencySituationRepositiry.GetCountEmergenciesByRegion("Брестская область")));
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("Витебская область", emergencySituationRepositiry.GetCountEmergenciesByRegion("Витебская область")));
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("Гомельская область", emergencySituationRepositiry.GetCountEmergenciesByRegion("Гомельская область")));
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("Гродненская область", emergencySituationRepositiry.GetCountEmergenciesByRegion("Гродненская область")));
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("Минская область", emergencySituationRepositiry.GetCountEmergenciesByRegion("Минская область")));
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("Могилевская область", emergencySituationRepositiry.GetCountEmergenciesByRegion("Могилевская область")));
            EmergenciesInfoByRegionList.Add(new KeyValuePair<string, int>("г.Минск", emergencySituationRepositiry.GetCountEmergenciesByRegion("г.Минск")));

        }
        private void FillOutStatusBarInfo()
        {
            int perished = 0;
            int perishedChildren = 0;
            foreach (var em in EmergencySituations)
            {
                perished +=(int)em.Perished;
                perishedChildren += (int)em.PerishedChildren;
            }
           if(perished!=0&&perishedChildren!=0) StatusBarInfo = $"За сутки на ЧС погибли {perished} человек, из них детей-{perishedChildren}";
            if (perished != 0 && perishedChildren == 0) StatusBarInfo = $"За сутки на ЧС погибли {perished} человек";
            if (perished == 0 && perishedChildren == 0) StatusBarInfo = $"За сутки погибших на ЧС нет";
        }
        private int GetNumberOfEmergencyPerDay(string _region)
        {
            int num = 0;
            foreach (var em in EmergencySituations)
            {
                
                if (em.Region == _region &&em.ToRegistration==true)
                {
                
                    num++;
                }
            }
            return num;
        }

    }
}