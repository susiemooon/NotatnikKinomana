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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotatnikKinomana
{
    /// <summary>
    /// Interaction logic for ListaFilmow.xaml
    /// </summary>
    public partial class ListaFilmowView : UserControl
    {
        
        public ListaFilmowView(List<Film> wyniki, MainWindowViewModel main)
        {
            InitializeComponent();
            ObservableCollection<Film> list;
            if (wyniki != null)
               list  = new ObservableCollection<Film>(wyniki);
            else
               list = new ObservableCollection<Film>();
            this.DataContext = new ListaFilmowViewModel(list, main);
            filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy;
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
                        filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy.OrderBy(x => x.nazwa);

                        break;
                    case "ZA":
                        this.filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy.OrderByDescending(x => x.nazwa);
                        break;
                    case "DataR":
                        this.filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy.OrderBy(x => x.data_premiery);
                        break;
                    case "DataM":
                        this.filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy.OrderByDescending(x => x.data_premiery);
                        break;
                    case "SredniaR":
                        this.filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy.OrderBy(x => x.srednia_ocen);
                        break;
                    case "SredniaM":
                        this.filmList.ItemsSource = ((ListaFilmowViewModel)this.DataContext).Filmy.OrderByDescending(x => x.srednia_ocen);
                        break;
                    default: break;
                }
            }

        }

    }
}
