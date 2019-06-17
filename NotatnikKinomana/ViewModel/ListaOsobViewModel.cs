using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.ViewModel
{
    class ListaOsobViewModel : ViewModelBase
    {
        private MainWindowViewModel mainVM;

        private ObservableCollection<Osoba> _osoby;
        public ObservableCollection<Osoba> Osoby
        {
            get
            {
                return _osoby;
            }

            set
            {
                _osoby = value;
                NotifyPropertyChanged();
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
                if(_wybranaOsoba != null)
                {
                    mainVM.CurrentView = new ProfilOsobyView(WybranaOsoba, mainVM);
                }
            }
        }

        public ListaOsobViewModel(ObservableCollection<Osoba> osoby, MainWindowViewModel main)
        {
            Osoby = osoby;
            this.mainVM = main;
            WybranaOsoba = null;
        }
    }
}
