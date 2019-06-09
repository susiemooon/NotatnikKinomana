using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotatnikKinomana.Models
{
    public enum Profesja
    {
        Aktor, Rezyser
    };

    public class Osoba
    {
        public int ID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int KrajID { get; set; }
        public Kraj pochodzenie { get; set; }
        public DateTime data_urodzenia { get; set; }
        public string biografia { get; set; }
        public string photo { get; set; }
        public Profesja profesja { get; set; }
        public virtual ICollection<Rola> role { get; set; }

        [NotMapped]
        public string ImieNazwisko
        {
            get
            {
                return imie + " " + nazwisko;
            } 
        }

        [NotMapped]
        public string MiejsceDataUrodzenia
        {
            get
            {
                return pochodzenie.nazwa + ", " + data_urodzenia.ToString("dd MMMM yyyy");
            }
        }
    }
}
