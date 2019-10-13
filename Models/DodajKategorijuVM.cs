using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomskiISpoljoprivreda.Models
{
    public class DodajKategorijuVM
    {
        public string Klijent { get; set; }
        public List<SelectListItem> Klijenti { get; set; }

        //public string Parcela { get; set; }
        public List<string> Kategorija { get; set; }
        public List<SelectListItem> Kategorije { get; set; }
    }
}