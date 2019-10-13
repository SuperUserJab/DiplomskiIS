using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomskiISpoljoprivreda.Models
{
    public class VijestIndexVM
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
    }

    public class VijestIndexListVM
    {
        public IEnumerable<VijestIndexVM> Vijesti { get; set; }
    }
}