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
    public class MyMessageBoxControlVM : ViewModelBase

    {
        private string text;
        public string Text
        {
            get { return text; }
            set { Set(nameof(Text), ref text, value); }
        }
        public RelayCommand OkCommand { set; get; }
       
        public MyMessageBoxControlVM ()
        {
            Messenger.Default.Register<String>(this, HandleText);
            //OkCommand= new RelayCommand(() =>
            //{
            //    DialogWindowVM.CloseWindow();
            //});
            OkCommand = new RelayCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if ((window as MyMessageBox) != null) window.Close();
                }
            });
        }
        private void HandleText(string t)
        {
            Text=t;

        }
    }
}
