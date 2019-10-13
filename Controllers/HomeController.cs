using DiplomskiISpoljoprivreda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomskiISpoljoprivreda.Controllers
{
    //[Authorize]
    //[Authorize("ImeUloge")]
    
    public class HomeController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        public ActionResult Index()
        {
            var vijesti = db.Vijesti.Select(v => new VijestIndexVM
            {
                Id = v.VijestID,
                Naslov = v.Naslov
            }).ToList();

            var model = new VijestIndexListVM
            {
                Vijesti = vijesti
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var termini = db.Termini.ToList();
            

            return View(termini);
        }
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime");
            return View();
        }
    }
}