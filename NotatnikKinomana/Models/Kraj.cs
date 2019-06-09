using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Kraj
    {
        public int ID { get; set; }
        public string nazwa { get; set; }

        public List<Film> filmy { get; set; }
        public List<Osoba> osoby { get; set; }
    }
}
