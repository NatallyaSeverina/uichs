using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UICHS.ViewModel
{
   public class AuthenticationControlVM:ViewModelBase
    {
        private string login;
        public string Login
        {
            get { return login; }
            set { Set(nameof(Login), ref login, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { Set(nameof(Password), ref password, value); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { Set(nameof(Message), ref message, value); }
        }
        public RelayCommand<object> LoginCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand UnLoadedCommand { get; set; }
        Model.IDutyOfficerRepository dutyOfficerRepository;
        Model.DutyOfficer d = new Model.DutyOfficer();
        public AuthenticationControlVM(Model.IDutyOfficerRepository _dutyOfficerRepository)
        {
            dutyOfficerRepository = _dutyOfficerRepository;

            UnLoadedCommand = new RelayCommand(() =>
            {
                ViewModelLocator.Cleanup();
            });
            LoginCommand = new RelayCommand<object>((commandParameter) =>
            {
                d = dutyOfficerRepository.GetByLogin(Login);
                this.Password = ((PasswordBox)commandParameter).Password;
                if (d == null)
                {
                    MyMessageBox _myMessageBox = new MyMessageBox();
                    Messenger.Default.Send("Неверный логин");
                    _myMessageBox.Show();
                   

                }
                else
                {
                    if (this.Password == d.PasswordDutyOfficer)
                    {

                        MainWindow mainWindow = new MainWindow();
                        Messenger.Default.Send(d);
                        mainWindow.Show();
                        foreach (Window window in Application.Current.Windows)
                        {
                            if ((window as DialogWindow) != null) window.Close();
                        }
                        
                    }
                    else
                    {
                        MyMessageBox _myMessageBox = new MyMessageBox();
                        Messenger.Default.Send("Неверный пароль");
                        _myMessageBox.Show();
                       

                    }

                }
               

            });
            CancelCommand = new RelayCommand(() =>
            {
                Environment.Exit(0);

            });

        }
        
    }
}
