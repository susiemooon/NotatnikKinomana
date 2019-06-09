using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
        public DateTime data_premiery { get; set; }
        public string plakat { get; set; }
        public float srednia_ocen { get; set; }
        public virtual ICollection<Kraj> kraje_produkcji { get; set; }
        public virtual ICollection<Gatunek> gatunki { get; set; }
        public virtual ICollection<Osoba> ekipa { get; set; }
        public virtual ICollection<Recenzja> recenzje { get; set; }

        [NotMapped]
        public string TytulRok
        {
            get
            {
                return nazwa + " (" + data_premiery.ToString("yyyy") + ")";
            }
        }

        [NotMapped]
        public string KrajeProdukcjiString
        {
            get
            {
                string result ="";
                foreach(Kraj k in kraje_produkcji)
                {
                    result += k.nazwa + ", ";
                }
                if(result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 2);
                }
                return result;
            }
        }

        /*public Film() { }

        public Film(Film film)
        {
            this.ID = film.ID;
            this.nazwa = film.nazwa;
            this.opis = film.opis;
            this.data_premiery = film.data_premiery;
            this.plakat = film.plakat;
            this.srednia_ocen = film.srednia_ocen;
            this.kraje_produkcji = film.kraje_produkcji;
            this.gatunki = film.gatunki;
            this.ekipa = film.ekipa;
            this.recenzje = film.recenzje;
        }*/
    }
}
