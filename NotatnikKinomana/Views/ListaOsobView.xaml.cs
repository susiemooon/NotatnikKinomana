using NotatnikKinomana.Models;
using NotatnikKinomana.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        
        public ListaOsobView(List<Osoba> lista, MainWindowViewModel main)
        {
            InitializeComponent();
            ObservableCollection<Osoba> list;
            if (lista != null)
                list = new ObservableCollection<Osoba>(lista);
            else
                list = new ObservableCollection<Osoba>();
            this.DataContext = new ListaOsobViewModel(list, main);
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
           
            RadioButton radioButton = (RadioButton)sender;
            string sortBy = radioButton.Name.ToString();
            if ((bool)radioButton.IsChecked)
            {
                switch (sortBy)
                {
                    case "AZ":
                        this.osobyList.ItemsSource = ((ListaOsobViewModel)this.DataContext).Osoby.OrderBy(x => x.imie);
                        break;
                    case "ZA":
                        this.osobyList.ItemsSource = ((ListaOsobViewModel)this.DataContext).Osoby.OrderByDescending(x => x.imie);
                        break;
                    case "NazwiskoAZ":
                        this.osobyList.ItemsSource = ((ListaOsobViewModel)this.DataContext).Osoby.OrderBy(x => x.nazwisko);
                        break;
                    case "NazwiskoZA":
                        this.osobyList.ItemsSource = ((ListaOsobViewModel)this.DataContext).Osoby.OrderByDescending(x => x.nazwisko);
                        break;

                    default: break;
                }
            }
        }

    }
}

    
