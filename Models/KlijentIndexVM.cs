using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomskiISpoljoprivreda.Models
{
    public class KlijentIndexVM
    {
        public int KlijentID { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }
        public string Ziroracun { get; set; }
        public string Vlasnistvo { get; set; }
        public decimal Kolicina { get; set; }
        public string Detalji { get; set; }
        public Nullable<bool> Aktivan { get; set; }

        public int BrojParcela { get; set; }
    }
}