/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:UICHS"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace UICHS.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AuthenticationControlVM>();
            SimpleIoc.Default.Register<UserSettingControlVM>();
            SimpleIoc.Default.Register<EmergencySituationControlVM>();
            SimpleIoc.Default.Register<MyMessageBoxControlVM>();
            SimpleIoc.Default.Register<EditEmergencySituationControlVM>();
            SimpleIoc.Default.Register<ChartControlVM>();

            SimpleIoc.Default.Register<Model.IDutyOfficerRepository, Repository.DutyOfficerRepository>();
            SimpleIoc.Default.Register<Model.IEmergencySituationRepositiry, Repository.EmergencySituationRepository>();
            SimpleIoc.Default.Register<Model.IVechicleRepository, Repository.VechicleRepository>();
            SimpleIoc.Default.Register<Model.IReportRepository, Repository.ReportRepository>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public AuthenticationControlVM AuthenticationVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AuthenticationControlVM>();
            }
        }
        public UserSettingControlVM UserSettingVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserSettingControlVM>();
            }
        }

        public  EmergencySituationControlVM EmergencySituationVM
        {
            
            get
            {
                return  ServiceLocator.Current.GetInstance<EmergencySituationControlVM>();
            }
        }
        public EditEmergencySituationControlVM EditEmergencySituationVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditEmergencySituationControlVM>();
            }
        }
        public MyMessageBoxControlVM MyMessageBoxVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyMessageBoxControlVM>();
            }
        }
        public ChartControlVM ChartVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChartControlVM>();
            }
        }

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<EditEmergencySituationControlVM>();
            SimpleIoc.Default.Register<EditEmergencySituationControlVM>();
            SimpleIoc.Default.Unregister<EmergencySituationControlVM>();
            SimpleIoc.Default.Register<EmergencySituationControlVM>();
            SimpleIoc.Default.Unregister<MainViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Unregister<AuthenticationControlVM>();
            SimpleIoc.Default.Register<AuthenticationControlVM>();
            SimpleIoc.Default.Unregister<UserSettingControlVM>();
            SimpleIoc.Default.Register<UserSettingControlVM>();
            SimpleIoc.Default.Unregister<MyMessageBoxControlVM>();
            SimpleIoc.Default.Register<MyMessageBoxControlVM>();
            SimpleIoc.Default.Unregister<DialogWindowVM>();
            SimpleIoc.Default.Register<DialogWindowVM>();



            // TODO Clear the ViewModels
        }
    }
}