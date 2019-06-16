using NotatnikKinomana.Models;
using NotatnikKinomana.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotatnikKinomana
{
    /// <summary>
    /// Interaction logic for ListaFilmow.xaml
    /// </summary>
    public partial class ListaFilmowView : UserControl
    {
        List<Film> wyniki;
        MainWindowViewModel main;
        public ListaFilmowView(List<Film> wyniki, MainWindowViewModel main)
        {
            InitializeComponent();
            this.wyniki = wyniki;
            this.main = main;
            this.DataContext = new ListaFilmowViewModel(wyniki, main);
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (wyniki == null)
                return;
            RadioButton radioButton = (RadioButton)sender;
            string sortBy = radioButton.Name.ToString();
            if ((bool)radioButton.IsChecked)
            {
                switch (sortBy)
                {
                    case "AZ":
                         wyniki.Sort(delegate(Film x, Film y)
                        {
                            return x.nazwa.CompareTo(y.nazwa);
                        });
                        main.CurrentView = new ListaFilmowView(wyniki, main);
                        break;
                    case "ZA":
                        wyniki.Sort(delegate (Film x, Film y)
                        {
                            return y.nazwa.CompareTo(x.nazwa);
                        });
                        main.CurrentView = new ListaFilmowView(wyniki, main);
                        break;
                    case "DataR":
                        wyniki.Sort(delegate (Film x, Film y)
                        {
                            return x.data_premiery.CompareTo(y.data_premiery);
                        });
                        main.CurrentView = new ListaFilmowView(wyniki, main);
                        break;
                    case "DataM":
                        wyniki.Sort(delegate (Film x, Film y)
                        {
                            return y.data_premiery.CompareTo(x.data_premiery);
                        });
                        main.CurrentView = new ListaFilmowView(wyniki, main);
                        break;
                    case "SredniaR":
                        wyniki.Sort(delegate (Film x, Film y)
                        {
                            return x.srednia_ocen.CompareTo(y.srednia_ocen);
                        });
                        main.CurrentView = new ListaFilmowView(wyniki, main);
                        break;
                    case "SredniaM":
                        wyniki.Sort(delegate (Film x, Film y)
                        {
                            return y.srednia_ocen.CompareTo(x.srednia_ocen);
                        });
                        main.CurrentView = new ListaFilmowView(wyniki, main);
                        break;
                    default: break;
                }
            }

        }

    }
}
