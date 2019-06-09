using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NotatnikKinomana.ViewModel
{
    class RejestracjaViewModel : ViewModelBase, IDialogRequestClose
    {
        private string _nazwaUzytkownika;
        public string NazwaUzytkownika
        {
            get
            {
                return _nazwaUzytkownika;
            }

            set
            {
                _nazwaUzytkownika = value;
                NotifyPropertyChanged();

            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                NotifyPropertyChanged();

            }
        }

        private string _haslo;
        public string Haslo
        {
            get
            {
                return _haslo;
            }

            set
            {
                _haslo = value;
                NotifyPropertyChanged();

            }
        }

        private string _powtorzoneHaslo;
        public string PowtorzoneHaslo
        {
            get
            {
                return _powtorzoneHaslo;
            }

            set
            {
                _powtorzoneHaslo = value;
                NotifyPropertyChanged();

            }
        }

        public RejestracjaViewModel()
        {
            ZarejestrujCommand = new RelayCommand(new Action<object>(Zarejestruj));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

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

        private ICommand _sprawdzHaslaCommand;
        public ICommand SprawdzHaslaCommand
        {
            get
            {
                return _sprawdzHaslaCommand;
            }
            set
            {
                _sprawdzHaslaCommand = value;
                NotifyPropertyChanged();
            }
        }

        public void Zarejestruj(object obj)
        {
            // TODO dodać walidację foramtu maila?
            // TODO dodać sprawdzenie czy nie ma takiego użytkownika
            if (NazwaUzytkownika == null || Email == null || Haslo == null || PowtorzoneHaslo == null)
            {
                MessageBox.Show("Pola nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
            else if(Haslo != null && Haslo != PowtorzoneHaslo)
            {
                MessageBox.Show("Hasła nie zgadzają się", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true, this.Content));
            }
        }

        public object[] Content
        {
            get
            {
                object[] res = new object[] { NazwaUzytkownika, Email, Haslo };
                return res;
            }

            set
            {
                if(value[0] != null && value[1] != null && value[2] != null)
                {
                    object[] data = value;
                    this.NazwaUzytkownika = (string)data[0];
                    this.Email = (string)data[1];
                    this.Haslo = (string)data[2];
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
