using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestSerwerTen.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
    }
}
