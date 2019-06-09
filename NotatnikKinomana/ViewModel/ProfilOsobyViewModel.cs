using NotatnikKinomana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.ViewModel
{
    class ProfilOsobyViewModel : ViewModelBase
    {
        private Osoba _osoba;
        public Osoba Osoba
        {
            get
            {
                return _osoba;
            }

            set
            {
                _osoba = value;
                NotifyPropertyChanged();
            }
        }

        private MainWindowViewModel mainVM;

        public ProfilOsobyViewModel(Osoba osoba, MainWindowViewModel main)
        {
            this.mainVM = main;
            this.Osoba = osoba;
        }
    }
}
