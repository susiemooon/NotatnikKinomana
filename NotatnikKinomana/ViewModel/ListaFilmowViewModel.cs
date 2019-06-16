using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
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

        private List<Film> _filmy;
        public List<Film> Filmy
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

        public ListaFilmowViewModel(List<Film> filmy, MainWindowViewModel main)
        {
            this.Filmy = filmy;
            this.mainVM = main;
            this.WybranyFilm = null;

           SortujCommand = new RelayCommand(new Action<object>(Sort));
        }

        private ICommand _SortujCommand;
        public ICommand SortujCommand
        {
            get
            {
                return _SortujCommand;
            }
            set
            {
                _SortujCommand = value;
                NotifyPropertyChanged();
            }
        }

        private void Sort(object sender)
        {
            //RadioButton radioButton = (RadioButton)sender;
            //string sortBy = radioButton.Content.ToString();
            //if ((bool)radioButton.IsChecked)
            //{
               // switch (sortBy)
                //{
                  //  case "A-Z":
                        Filmy.Sort(delegate (Film x, Film y)
                        {
                            return x.nazwa.CompareTo(y.nazwa);
                        });
             
                        //this.DataContext = new ListaFilmowViewModel(wyniki, main); 
                        mainVM.CurrentView = new ListaFilmowView(Filmy, mainVM);

                    //    break;
                    //default: break;
                //}
            //}

        }
    }
}
