using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class DoObejrzeniaFilm
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public virtual Film film {get;set;}
        public virtual ICollection<Uzytkownik> uzytkownicy { get; set; }
    }
}
