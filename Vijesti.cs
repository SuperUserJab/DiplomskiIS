//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomskiISpoljoprivreda
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vijesti
    {
        public int VijestID { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public System.DateTime Datum { get; set; }
        public int UlogaID { get; set; }
    
        public virtual Uloga Uloga { get; set; }
    }
}
