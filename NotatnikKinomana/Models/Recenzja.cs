﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikKinomana.Models
{
    public class Recenzja
    {
        public int ID { get; set; }
        public string tytul { get; set; }
        public string tekst { get; set; }
        public int ocena { get; set; }

        public string autorID { get; set; }
        public virtual Uzytkownik autor { get; set; }
        public int FilmID { get; set; }
        public virtual Film film { get; set; }
    }
}
