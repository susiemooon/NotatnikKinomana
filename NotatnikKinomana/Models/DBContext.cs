using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace NotatnikKinomana.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DefaultConnection")
        {

        }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Recenzja> Recenzji { get; set; }

    }
}
