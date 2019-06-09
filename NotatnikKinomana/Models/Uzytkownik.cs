using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Uzytkownik
    {
        [Key]
        public string username { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }

        public virtual ICollection<Recenzja> Recenzje { get; set; }
        public virtual ICollection<ObejrzanyFilm> ObejrzaneFilmy { get; set; }
        public virtual ICollection<DoObejrzeniaFilm> DoObejrzeniaFilmy { get; set; }
    }
}
