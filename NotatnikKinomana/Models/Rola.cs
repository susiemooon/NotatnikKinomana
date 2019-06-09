using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Rola
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string photo { get; set; }
        public int filmID { get; set; }
        public Film film { get; set; }
        public int aktorID { get; set; }
        public Osoba aktor { get; set; }
    }
}
