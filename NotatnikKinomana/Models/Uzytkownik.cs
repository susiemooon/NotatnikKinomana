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
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        
    }
}
