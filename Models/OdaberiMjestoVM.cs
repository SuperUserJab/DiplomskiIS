using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomskiISpoljoprivreda.Models
{
    public class OdaberiMjestoVM
    {
        public int ParcelaId { get; set; }

        public string MjestoId { get; set; }
        public List<SelectListItem> Mjesta { get; set; }
    }
}