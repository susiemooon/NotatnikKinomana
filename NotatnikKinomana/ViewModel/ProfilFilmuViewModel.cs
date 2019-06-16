using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NotatnikKinomana.ViewModel
{
    class ProfilFilmuViewModel : ViewModelBase
    {
        private MainWindowViewModel mainVM;

        private Film _film;
        public Film Film
        {
            get
            {
                return _film;
            }

            set
            {
                _film = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get
            {
                DBContext context = new DBContext();
                var user = context.Uzytkownicy.SingleOrDefault(u => u.username == mainVM.Uzytkownik.username);
                _isChecked = user.DoObejrzeniaFilmy.Any(f => f.FilmID == Film.ID);
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                NotifyPropertyChanged();
                if (_isChecked)
                    DodajDoObejrzenia(Film);
                else UsunDoObejrzenia(Film);
            }
        }

        private void DodajDoObejrzenia(Film film)
        {
            using (DBContext context = new DBContext())
            {
                Uzytkownik user = context.Uzytkownicy.SingleOrDefault(u => u.username == mainVM.Uzytkownik.username);

                if (user != null && !user.DoObejrzeniaFilmy.Any(f => f.FilmID == film.ID))
                {
                    DoObejrzeniaFilm doObejrzenia = context.DoObejrzenia.SingleOrDefault(f => f.FilmID == film.ID);

                    if (doObejrzenia == null)
                    {
                        doObejrzenia = new DoObejrzeniaFilm { FilmID = film.ID };
                        context.DoObejrzenia.Add(doObejrzenia);
                    }
                    if (doObejrzenia.uzytkownicy == null)
                    {
                        doObejrzenia.uzytkownicy = new List<Uzytkownik>();
                    }

                    doObejrzenia.uzytkownicy.Add(user);
                    user.DoObejrzeniaFilmy.Add(doObejrzenia);
                    context.SaveChanges();
                }
            }
        }

        private void UsunDoObejrzenia(Film film)
        {
            DBContext context = new DBContext();
            Uzytkownik user = context.Uzytkownicy.SingleOrDefault(u => u.username == mainVM.Uzytkownik.username);
            DoObejrzeniaFilm doObejrzenia = context.DoObejrzenia.SingleOrDefault(f => f.FilmID == film.ID);

            if (user.DoObejrzeniaFilmy.Any(f => f.FilmID == film.ID))
            {
                if (doObejrzenia != null)
                {
                    doObejrzenia.uzytkownicy.Remove(user);

                }
                if (doObejrzenia.uzytkownicy.Count == 0)
                {
                    context.DoObejrzenia.Remove(doObejrzenia);
                }
                user.DoObejrzeniaFilmy.Remove(doObejrzenia);
                context.SaveChanges();
            }
        }

        private ICommand _ocenFilmCommand;
        public ICommand OcenFilmCommand
        {
            get
            {
                return _ocenFilmCommand;
            }
            set
            {
                _ocenFilmCommand = value;
                NotifyPropertyChanged();
            }
        }

        private void OcenFilm(object obj)
        {
            using (DBContext context = new DBContext())
            {
                var recenzjaVM = new RecenzjaViewModel(Film);

                // Wyświetlanie dialogu logowania
                bool? recenzjaResult = mainVM.dialogService.ShowDialog(recenzjaVM);

                if (recenzjaResult.HasValue)
                {
                    // Dodawanie recenzji, jeśli zwrócono True
                    if (recenzjaResult.Value)
                    {
                        var recenzjeEntity = context.Recenzje;
                        Recenzja recenzja = recenzjeEntity.SingleOrDefault(r => r.autor.username == mainVM.Uzytkownik.username && r.FilmID == Film.ID);

                        // Przypisywanie istniejącej recenzji
                        if (recenzja == null)
                        {
                            recenzja = new Recenzja { FilmID = Film.ID, autorID = mainVM.Uzytkownik.username, film = Film, autor = mainVM.Uzytkownik };
                        }
                        else
                        {
                            recenzjaVM.Content[0] = recenzja.tytul;
                            recenzjaVM.Content[1] = recenzja.tekst;
                            recenzjaVM.Content[2] = recenzja.ocena;
                        }

                        recenzja.tytul = (string)recenzjaVM.Content[0];
                        recenzja.tekst = (string)recenzjaVM.Content[1];
                        recenzja.ocena = (int)recenzjaVM.Content[2];

                        // srednia ocen 
                        Film film = context.Filmy.SingleOrDefault(f => f.ID == recenzja.FilmID);
                        if (film.srednia_ocen != 0)
                            film.srednia_ocen = (film.srednia_ocen + recenzja.ocena) / 2;
                        else
                            film.srednia_ocen += recenzja.ocena;
                                                
                        context.Recenzje.AddOrUpdate(recenzja);
                        context.Filmy.AddOrUpdate(film);
                        context.SaveChanges();
                    }
                }
            }
        }

        private Osoba _wybranaOsoba;
        public Osoba WybranaOsoba
        {
            get
            {
                return _wybranaOsoba;
            }

            set
            {
                _wybranaOsoba = value;
                NotifyPropertyChanged();
                if (_wybranaOsoba != null)
                {
                    mainVM.CurrentView = new ProfilOsobyView(WybranaOsoba, mainVM);
                }
            }
        }

        public ProfilFilmuViewModel(int ID, MainWindowViewModel main)
        {
            DBContext context = new DBContext();

            Film = context.Filmy.Where(film => film.ID == ID).Single();
            mainVM = main;
            OcenFilmCommand = new RelayCommand(new Action<object>(OcenFilm));
        }
    }
}
