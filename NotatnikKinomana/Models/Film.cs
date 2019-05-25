using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Film
    {
        public string nazwa { get; set; }
        public List<Aktor> actorzy { get; set; } 
        public string opis { get; set; }
        public DateTime data_premiery { get; set; }
        public string afisha { get; set; }
        public float srednia_ocen { get; set; }

        public Film(string nazwa, List<Aktor> aktorzy, string opis, DateTime data_premiery, string afisha)
        {
            this.nazwa = nazwa;
            this.actorzy = actorzy;
            this.opis = opis;
            this.data_premiery = data_premiery;
            this.afisha = afisha;
        }

    }
}
