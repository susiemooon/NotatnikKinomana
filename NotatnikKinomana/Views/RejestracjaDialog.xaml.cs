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
using NotatnikKinomana.Models;
using System.Data.Entity;


namespace NotatnikKinomana
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window, IDialog
    {
        public Rejestracja()
        {
            InitializeComponent();
        }

        private void PasswordTB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Haslo = ((PasswordBox)sender).Password; }
        }

        private void ConfirmPasswordTB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).PowtorzoneHaslo = ((PasswordBox)sender).Password; }
        }
    }
}
