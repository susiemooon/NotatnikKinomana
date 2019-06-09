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
        public ListaOsobView(List<Osoba> lista, MainWindowViewModel main)
        {
            InitializeComponent();
            this.DataContext = new ListaOsobViewModel(lista, main);
        }
    }
}
