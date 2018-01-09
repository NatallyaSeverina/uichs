using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UICHS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherHelper.Initialize();
            bool createdNew;
            string mutName = "ПриложениеУИЧС";
            mutex = new System.Threading.Mutex(true, mutName, out createdNew);
            if (!createdNew)
            {
                this.Shutdown();
            }
            base.OnStartup(e);
            AuthenticationControl authenticationControl = new AuthenticationControl();
            DialogWindow dialogWindow = new DialogWindow(authenticationControl);
            dialogWindow.Show();

        }
        System.Threading.Mutex mutex;
     
    }
}
