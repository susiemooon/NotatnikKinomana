using NotatnikKinomana.Models;
using NotatnikKinomana.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotatnikKinomana.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IDialogService dialogService { get; set; }

        private static MainWindowViewModel _instance = new MainWindowViewModel();
        public static MainWindowViewModel Instance { get { return _instance; } }

        public MainWindowViewModel()
        {
            TypWyszukiwania = "film";
            SzukajCommand = new RelayCommand(new Action<object>(Szukaj));
            PokazLogowanieCommand = new RelayCommand(new Action<object>(PokazLogowanie));
            PokazUzytkownikaCommand = new RelayCommand(new Action<object>(PokazUzytkownika));
        }

        private static UserControl _currentView;
        public UserControl CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                NotifyPropertyChanged();
            }
        }

        public void SetView(UserControl view)
        {
            CurrentView = view;
        }

        private static Uzytkownik _uzytkownik;
        public Uzytkownik Uzytkownik
        {
            get
            {
                return _uzytkownik;
            }

            set
            {
                _uzytkownik = value;
                NotifyPropertyChanged();
            }
        }

        private string _tekstWyszukiwania;
        public string TekstWyszukiwania
        {
            get
            { return _tekstWyszukiwania; }
            set
            {
                _tekstWyszukiwania = value;
                NotifyPropertyChanged();
            }
        }

        private string _typWyszukiwania;
        public string TypWyszukiwania
        {
            get
            { return _typWyszukiwania; }
            set
            {
                _typWyszukiwania = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _SzukajCommand;
        public ICommand SzukajCommand
        {
            get
            {
                return _SzukajCommand;
            }
            set
            {
                _SzukajCommand = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _PokazFilmCommand;
        public ICommand PokazFilmCommand
        {
            get
            {
                return _PokazFilmCommand;
            }
            set
            {
                _PokazFilmCommand = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand _PokazLogowanieCommand;
        public ICommand PokazLogowanieCommand
        {
            get
            {
                return _PokazLogowanieCommand;
            }
            set
            {
                _PokazLogowanieCommand = value;
                NotifyPropertyChanged();
            }
        }

        private void Szukaj(object obj)
        {
            DBContext context = new DBContext();

            if (TypWyszukiwania == "film")
            {
                var wyniki = context.Filmy.Where(film => film.nazwa.ToLower().Contains(TekstWyszukiwania.ToLower())).ToList();
                CurrentView = new ListaFilmowView(wyniki, this);
            }
            else
            {
                var wyniki = context.Osoby.Where(osoba => osoba.imie.ToLower().Contains(TekstWyszukiwania.ToLower()) ||
                                                            osoba.nazwisko.ToLower().Contains(TekstWyszukiwania)).ToList();
                CurrentView = new ListaOsobView(wyniki, this);
            }
        }

        private void PokazLogowanie(object obj)
        {
            var loginVM = new LoginViewModel();
            DBContext context = new DBContext();

            // Wyświetlanie dialogu logowania
            bool? loginResult = dialogService.ShowDialog(loginVM);

            if (loginResult.HasValue)
            {
                // Logowanie, jeśli zwrócono True
                if (loginResult.Value)
                {
                    // Znajdowanie użytkownika w bazie
                    string nazwaUzytkownika = (string)loginVM.Content[0];
                    string haslo = (string)loginVM.Content[1];
                    Uzytkownik uzytkownik = context.Uzytkownicy.ToList().Where(u => u.username == nazwaUzytkownika).First();

                    // Sprawdzanie czy użytkownik znaleziony i hasło się zgadza
                    if (uzytkownik != null && haslo == uzytkownik.haslo)
                    {
                        Uzytkownik = uzytkownik;
                    }
                    else        // Jeśli brak użytkownika lub nieprawidłowe hasło
                    {
                        MessageBox.Show("Nie znaleziono użytkownika lub nieprawidłowe hasło");
                        this.PokazLogowanieCommand.Execute(null);
                    }
                }
                else          // Rejestracja, jeśli zwrócono False
                {
                    var rejestracjaVM = new RejestracjaViewModel();

                    // Wyświetlanie dialogu rejestracji
                    bool? rejestracjaResult = dialogService.ShowDialog(rejestracjaVM);

                    if (rejestracjaResult.HasValue)
                    {
                        // Dodawanie użytkownika do bazy i logowanie
                        if (rejestracjaResult.Value)
                        {
                            string nazwaUzytkownika = (string)rejestracjaVM.Content[0];
                            string email = (string)rejestracjaVM.Content[1];
                            string haslo = (string)rejestracjaVM.Content[2];

                            Uzytkownik nowy = new Uzytkownik { username = nazwaUzytkownika, haslo = haslo, email = email };
                            context.Uzytkownicy.Add(nowy);
                            context.SaveChanges();
                            Uzytkownik = nowy;
                        }
                    }
                }
            }
        }

        private ICommand _PokazUzytkownikaCommand;
        public ICommand PokazUzytkownikaCommand
        {
            get
            {
                return _PokazUzytkownikaCommand;
            }
            set
            {
                _PokazUzytkownikaCommand = value;
                NotifyPropertyChanged();
            }
        }

        private void PokazUzytkownika(object obj)
            {
                this.CurrentView = new ProfilUzytkownikaView(this);
            }
    }
}