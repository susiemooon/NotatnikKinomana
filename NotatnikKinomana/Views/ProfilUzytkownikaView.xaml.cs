using NotatnikKinomana.Models;
using NotatnikKinomana.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProfilUzytkownikaView.xaml
    /// </summary>
    public partial class ProfilUzytkownikaView : UserControl
    {
        
        public ProfilUzytkownikaView(MainWindowViewModel main)
        {
            InitializeComponent();
            
            this.DataContext = new ProfilUzytkownikaViewModel(main);
            DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia;
            ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane;

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
                        this.DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia.OrderBy(x => x.nazwa);
                        
                        break;
                    case "ZA":
                        this.DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia.OrderByDescending(x => x.nazwa);
                        break;
                    case "DataR":
                        this.DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia.OrderBy(x => x.data_premiery);
                        break;
                    case "DataM":
                        this.DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia.OrderByDescending(x => x.data_premiery);
                        break;
                    case "SredniaR":
                        this.DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia.OrderBy(x => x.srednia_ocen);
                        break;
                    case "SredniaM":
                        this.DoObejrzeniaLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).DoObejrzenia.OrderByDescending(x => x.srednia_ocen);
                        break;
                    case "AZ_O":
                        this.ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane.OrderBy(x => x.nazwa);

                        break;
                    case "ZA_O":
                        this.ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane.OrderByDescending(x => x.nazwa);
                        break;
                    case "DataR_O":
                        this.ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane.OrderBy(x => x.data_premiery);
                        break;
                    case "DataM_O":
                        this.ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane.OrderByDescending(x => x.data_premiery);
                        break;
                    case "SredniaR_O":
                        this.ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane.OrderBy(x => x.srednia_ocen);
                        break;
                    case "SredniaM_O":
                        this.ObejrzaneLB.ItemsSource = ((ProfilUzytkownikaViewModel)this.DataContext).Obejrzane.OrderByDescending(x => x.srednia_ocen);
                        break;
                    default: break;
                }
            }
        }
    }
}
