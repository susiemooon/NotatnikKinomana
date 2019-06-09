using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Gatunek
    {
        public int ID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Film> filmy { get; set; }
    }
}
