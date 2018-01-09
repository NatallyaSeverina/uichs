using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICHS.ViewModel
{
   public class UserSettingControlVM:ViewModelBase
    {
        private Model.DutyOfficer dutyOfficer;
        public Model.DutyOfficer DutyOfficer
        {
            get { return dutyOfficer; }
            set { Set(nameof(DutyOfficer), ref dutyOfficer, value); }
        }
        Model.IDutyOfficerRepository dutyOfficerRepository;
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand UnLoadedCommand { get; set; }
        public UserSettingControlVM(Model.IDutyOfficerRepository _dutyOfficerRepository)
        {
            dutyOfficerRepository = _dutyOfficerRepository;
            Messenger.Default.Register<Model.DutyOfficer>(this, HandleDutyOfficer);
            SaveCommand = new RelayCommand(() =>
            {
                dutyOfficerRepository.SaveDutyOfficerSettings(DutyOfficer);
                DialogWindowVM.CloseWindow();
             
            });
            CancelCommand = new RelayCommand(() =>
            {
                DialogWindowVM.CloseWindow();

            });
            UnLoadedCommand = new RelayCommand(() =>
            {
                ViewModelLocator.Cleanup();
            });

        }
        private void HandleDutyOfficer(Model.DutyOfficer d)
        {
           DutyOfficer = d;

        }
        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}
