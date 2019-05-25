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
    public partial class Rejestracja : Window
    {
        DBContext db;

        public Rejestracja()
        {
            InitializeComponent();
            db = new DBContext();
        }

        private void Zarejestruj_Click(object sender, RoutedEventArgs e)
        {
            if (passwordTB.Password.ToString() == confirmPasswordTB.Password.ToString())
            {
                Uzytkownik u = new Uzytkownik();
                u.username = usernameTB.Text;
                u.email = emailTB.Text;
                u.haslo = passwordTB.Password.ToString();
                db.Uzytkownicy.Add(u);
                db.SaveChanges();
            }
        }
    }
}
