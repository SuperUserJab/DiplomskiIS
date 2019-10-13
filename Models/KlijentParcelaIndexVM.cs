using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomskiISpoljoprivreda.Models
{
    public class KlijentParcelaIndexVM
    {
        public string Klijent { get; set; }

        public IEnumerable<string> Parcele { get; set; }
    }
}