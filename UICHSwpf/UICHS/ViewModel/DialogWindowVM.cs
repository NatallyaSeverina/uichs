using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UICHS.ViewModel
{
   public class DialogWindowVM: ViewModelBase
    {
       
        private UserControl userControlView;

        public UserControl UserControlView
        {
            get { return userControlView; }
            set { Set(() => UserControlView, ref userControlView, value); }
        }
        private static Window window;

        public DialogWindowVM(UserControl _uc, Window _window )
        {
           window = _window;
           
           this.UserControlView = _uc ;
            if(UserControlView is AuthenticationControl)
            {
                window.Height = 180;
                window.Width = 190;
            }
            if(UserControlView is UserSettingControl)
            {
                window.Height = 300;
                window.Width = 260;

            }
            if (UserControlView is EmergencySituationControl)
            {

                window.Height = 800;
                window.Width = 1000;

            }
            if (UserControlView is EditEmergencySituationControl)
            {

                window.Height = 800;
                window.Width = 1000;

            }
           

        }
        public static void CloseWindow()
        {
           
            window.Close();
        }
        public static void CloseDialogWindow()
        {
            window.DialogResult = true;
            //window.Close();
        }
    }
}
