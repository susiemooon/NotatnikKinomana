using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Aktor
    {
        public string imie_nazwisko { get; set; }
        public string pochodzenie { get; set; }
        public string data_urodzenia { get; set; }
        public string biografia { get; set; }
        List<string> role { get; set; }
        public string photo { get; set; }

        public Aktor(string imie_nazwisko, string pochodzenie, string data_urodzenia, string bio, List<string> role, string photo)
        {
            this.imie_nazwisko = imie_nazwisko;
            this.pochodzenie = pochodzenie;
            this.data_urodzenia = data_urodzenia;
            this.biografia = bio;
            this.role = role;
            this.photo = photo;
        }
    }
}
