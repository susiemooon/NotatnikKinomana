using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotatnikKinomana.ViewModel
{
    class ListaFilmowViewModel : ViewModelBase
    {
        private MainWindowViewModel mainVM;

        private ObservableCollection<Film> _filmy;
        public ObservableCollection<Film> Filmy
        {
            get
            {
                return _filmy;
            }

            set
            {
                _filmy = value;
                NotifyPropertyChanged();
            }

        }

        private Film _wybranyFilm;
        public Film WybranyFilm
        {
            get
            {
                return _wybranyFilm;
            }

            set
            {
                _wybranyFilm = value;
                NotifyPropertyChanged();
                if(_wybranyFilm != null)
                {
                    mainVM.CurrentView = new ProfilFilmuView(_wybranyFilm.ID, mainVM);
                }
            }

        }

        public ListaFilmowViewModel(ObservableCollection<Film> filmy, MainWindowViewModel main)
        {
            this.Filmy = filmy;
            this.mainVM = main;
            this.WybranyFilm = null;

           
        }

        

        
    }
}
