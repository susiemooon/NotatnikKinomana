using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikKinomana.ViewModel
{
    class LoginViewModel : ViewModelBase, IDialogRequestClose
    {
        private string _nazwaUzytkownika;
        public string NazwaUzytkownika
        {
            get
            { return _nazwaUzytkownika;
            }

            set
            {
                _nazwaUzytkownika = value;
                NotifyPropertyChanged();
           
            }
        }

        private string _haslo;
        public string Haslo
        {
            get
            {
                return _haslo ;
            }

            set
            {
                _haslo = value;
                NotifyPropertyChanged();

            }
        }

        public LoginViewModel()
        {
            ZalogujCommand = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true, this.Content)));
            ZarejestrujCommand = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _ZalogujCommand;
        public ICommand ZalogujCommand
        {
            get
            {
                return _ZalogujCommand;
            }
            set
            {
                _ZalogujCommand = value;
                NotifyPropertyChanged();
            }
        }       

        private ICommand _ZarejestrujCommand;
        public ICommand ZarejestrujCommand
        {
            get
            {
                return _ZarejestrujCommand;
            }
            set
            {
                _ZarejestrujCommand = value;
                NotifyPropertyChanged();
            }
        }

        public object[] Content
        {
            get
            {
                object[] res = new object[] { NazwaUzytkownika, Haslo };
                return res;
            }

            set
            {
                if(value != null && value.Length == 2)
                {
                    object[] data = value;
                    this.NazwaUzytkownika = (string)data[0];
                    this.Haslo = (string)data[1];
                    NotifyPropertyChanged();
                }   
            }
        }
    }
}
