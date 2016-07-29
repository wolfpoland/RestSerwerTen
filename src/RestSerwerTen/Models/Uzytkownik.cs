using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestSerwerTen.Models
{
    public class uzytkownik
    {
        public int Id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string mail { get; set; }
        public string haslo { get; set; }
    }
}
