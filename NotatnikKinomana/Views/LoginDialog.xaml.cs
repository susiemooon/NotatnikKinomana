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
using NotatnikKinomana.ViewModel;

namespace NotatnikKinomana
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window, IDialog
    {
        public Login()
        {
            InitializeComponent();
        }

        private void PasswordTB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Haslo = ((PasswordBox)sender).Password; }
        }
    }
}
