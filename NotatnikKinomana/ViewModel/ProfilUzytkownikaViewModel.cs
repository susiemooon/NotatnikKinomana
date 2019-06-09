using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.ViewModel
{
    class ProfilUzytkownikaViewModel : ViewModelBase
    {
        private MainWindowViewModel mainVM;

        private Film _wybranyFilm;
        public Film WybranyFilm
        {
            get
            {
                return _wybranyFilm;
            }

            set
            {
                if(_wybranyFilm != value)
                {
                    _wybranyFilm = value;
                    NotifyPropertyChanged();
                    mainVM.CurrentView = new ProfilFilmuView(_wybranyFilm.ID, mainVM);
                }
            }
        }


        private Uzytkownik _uzytkownik;
        public Uzytkownik Uzytkownik {
            get {
                return _uzytkownik; }

            set
            {
                _uzytkownik = value;
                NotifyPropertyChanged();
            }
        }

        private List<Film> _doObejrzenia;
        public List<Film> DoObejrzenia
        {
            get
            {
                return _doObejrzenia;
            }

            set
            {
                _doObejrzenia = value;
                NotifyPropertyChanged();
            }
        }

        private void UtworzListeDoObejrzenia()
        {
            DBContext context = new DBContext();

            _doObejrzenia = new List<Film>();
            var original = Uzytkownik.DoObejrzeniaFilmy;
            foreach (DoObejrzeniaFilm dof in original)
            {
                  DoObejrzenia.Add(dof.film);
            }
        }

        private List<Film> _obejrzane;
        public List<Film> Obejrzane
        {
            get
            {
                return _obejrzane;
            }

            set
            {
                _obejrzane = value;
                NotifyPropertyChanged();
            }
        }

        private void UtworzListeObejrzane()
        {
            DBContext context = new DBContext();

            Obejrzane = new List<Film>();
            var original = Uzytkownik.ObejrzaneFilmy;
            foreach (ObejrzanyFilm of in original)
            {
                    Obejrzane.Add(of.film);
            }
        }

        public ProfilUzytkownikaViewModel(MainWindowViewModel main)
        {
            this.mainVM = main;
            Uzytkownik = mainVM.Uzytkownik;
            UtworzListeDoObejrzenia();
            UtworzListeObejrzane();
        }
    }
}
