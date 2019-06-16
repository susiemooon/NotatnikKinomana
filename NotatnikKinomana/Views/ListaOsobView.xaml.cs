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
using System.Windows.Shapes;

namespace NotatnikKinomana.Views
{
    /// <summary>
    /// Interaction logic for ListaOsobView.xaml
    /// </summary>
    public partial class ListaOsobView : UserControl
    {

        List<Osoba> lista;
        MainWindowViewModel main;
        public ListaOsobView(List<Osoba> lista, MainWindowViewModel main)
        {
            InitializeComponent();
            this.lista = lista;
            this.main = main;
            this.DataContext = new ListaOsobViewModel(lista, main);
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (lista == null)
                return;


            RadioButton radioButton = (RadioButton)sender;
            string sortBy = radioButton.Name.ToString();
            if ((bool)radioButton.IsChecked)
            {
                switch (sortBy)
                {
                    case "AZ":
                        lista.Sort(delegate (Osoba x, Osoba y)
                        {
                            return x.imie.CompareTo(y.imie);
                        });
                        main.CurrentView = new ListaOsobView(lista, main);
                        break;
                    case "ZA":
                        lista.Sort(delegate (Osoba x, Osoba y)
                        {
                            return y.imie.CompareTo(x.imie);
                        });
                        main.CurrentView = new ListaOsobView(lista, main);
                        break;
                    case "NazwiskoAZ":
                        lista.Sort(delegate (Osoba x, Osoba y)
                        {
                            return x.nazwisko.CompareTo(y.nazwisko);
                        });
                        main.CurrentView = new ListaOsobView(lista, main);
                        break;
                    case "NazwiskoZA":
                        lista.Sort(delegate (Osoba x, Osoba y)
                        {
                            return y.nazwisko.CompareTo(x.nazwisko);
                        });
                        main.CurrentView = new ListaOsobView(lista, main);
                        break;

                    default: break;
                }
            }
        }

    }
}

    
