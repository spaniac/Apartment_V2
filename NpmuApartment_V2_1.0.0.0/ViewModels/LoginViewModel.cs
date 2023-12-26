using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using NpmuApartment_V2.Helpers;

namespace NpmuApartment_V2.ViewModels
{
    public class LoginViewModel : ViewModelBase<LoginViewModel>
    {
        private string _id = string.Empty;

        public string Id
        {
            get => _id;
            set
            {
                _id = value; 
                NotifyPropertyChanged();
            }
        }

        private string _pw = string.Empty;

        public string Pw
        {
            get => _pw;
            set
            {
                _pw = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isIdSave = false;

        public bool IsIdSave
        {
            get => _isIdSave;
            set
            {
                _isIdSave = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand CmdLogin { get; set; }

        public RelayCommand CmdExit { get; set; }

        public LoginViewModel()
        {
            this.CmdLogin = new RelayCommand(this.Login, ob => !string.IsNullOrEmpty(this.Id));
            this.CmdExit = new RelayCommand(this.Exit);
        }

        public void Login(object pParam)
        {
            /*
             * - ID, PW 확인
             * - 계정정보 메모리에 저장
             * - 권한 확인
             * - 권한에 맞는 화면 UI, 객체 생성
             */
        }

        public void Exit(object pParam)
        {
            Application.Current.Shutdown();
        }
    }
}
