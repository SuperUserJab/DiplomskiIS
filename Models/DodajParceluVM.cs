using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomskiISpoljoprivreda.Models
{
    public class DodajParceluVM
    {
        public string Klijent { get; set; }
        public List<SelectListItem> Klijenti { get; set; }

        //public string Parcela { get; set; }
        public List<string> Parcela { get; set; }
        public List<SelectListItem> Parcele { get; set; }
    }
}