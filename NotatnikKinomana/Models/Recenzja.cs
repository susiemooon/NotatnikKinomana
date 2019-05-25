using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Recenzja
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string nazwa_filmu { get; set; }
        public string tytul { get; set; }
        public string tekst { get; set; }
        public int ocena { get; set; }
    }
}
