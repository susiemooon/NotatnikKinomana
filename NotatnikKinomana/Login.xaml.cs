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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        DBContext db;
        public string currentUser;
        public Login()
        {
            InitializeComponent();
            db = new DBContext();
        }

        private void Zaloguj_Click(object sender, RoutedEventArgs e)
        {
            List<Uzytkownik> users = db.Uzytkownicy.ToList();
            Uzytkownik user = users.Where(u => u.username == usernameTB.Text).FirstOrDefault();
            if (user!=null && passwordTB.Password.ToString() == user.haslo)
            {
                currentUser = user.username;
                this.Close();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Nie prawidlowa nazwa użytkownika albo haslo!", "Alert", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    usernameTB.Text = "";
                    passwordTB.Password = "";
                }
            }

        }
    }
}
