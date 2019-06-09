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

        public ListaFilmowView(List<Film> wyniki, MainWindowViewModel main)
        {
            InitializeComponent();
            this.DataContext = new ListaFilmowViewModel(wyniki, main);
        }

    }
}
