using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NotatnikKinomana.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DefaultConnection")
        {

        }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Recenzja> Recenzje { get; set; }
        public DbSet<Film> Filmy { get; set; }
        public DbSet<DoObejrzeniaFilm> DoObejrzenia { get; set; }
        public DbSet<ObejrzanyFilm> Obejrzane { get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Gatunek> Gatunki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
