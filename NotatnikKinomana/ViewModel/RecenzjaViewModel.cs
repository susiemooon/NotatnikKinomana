using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikKinomana.ViewModel
{
    class RecenzjaViewModel : ViewModelBase, IDialogRequestClose
    {
        private Film film;

        public string TytulOkna
        {
            get
            {
                return "Recenzja filmu " + film.nazwa;
            }
        }

        private string _tytul = "";
        public string Tytul
        {
            get
            {
                return _tytul;
            }

            set
            {
                _tytul = value;
                NotifyPropertyChanged();
            }
        }

        private string _tresc = "";
        public string Tresc
        {
            get
            {
                return _tresc;
            }

            set
            {
                _tresc = value;
                NotifyPropertyChanged();
            }
        }

        private int _ocena;
        public int Ocena
        {
            get
            {
                return _ocena;
            }

            set
            {
                _ocena = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _anulujCommand;
        public ICommand AnulujCommand
        {
            get
            {
                return _anulujCommand;
            }

            set
            {
                _anulujCommand = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _dodajRecenzjeCommand;
        public ICommand DodajRecenzjeCommand
        {
            get
            {
                return _dodajRecenzjeCommand;
            }

            set
            {
                _dodajRecenzjeCommand = value;
                NotifyPropertyChanged();
            }
        }

        public object[] Content {
            get
            {
                object[] res = new object[] { Tytul, Tresc, Ocena};
                return res;
            }

            set
            {
                if (value[2] != null)
                {
                    object[] data = value;
                   
                    if(value[0] != null && value[1] != null)
                    {
                        this.Tytul = (string)data[0];
                        this.Tresc = (string)data[1];
                    }
                    else
                    {
                        this.Tytul = "";
                        this.Tresc = "";
                    }

                    this.Ocena = (int)data[2];
                    NotifyPropertyChanged();
                }
            }
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public RecenzjaViewModel(Film film)
        {
            this.film = film;
            AnulujCommand = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false, this.Content)));
            DodajRecenzjeCommand = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true, this.Content)));
        }
    }
}
