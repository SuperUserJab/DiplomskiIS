using DiplomskiISpoljoprivreda.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomskiISpoljoprivreda.Controllers
{
    public class KlijentParcelaController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();
        
        // GET: KlijentParcela
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DodajParcelu()
        {
            var parcele = db.BrojParcele.Select(p => new SelectListItem
            {
                Text = p.BrojParcele1,
                Value = p.ParcelaID.ToString()
            }).ToList();

            var klijenti = db.Klijent.Select(k => new SelectListItem
            {
                Text = k.Ime + " " + k.Prezime,
                Value = k.KlijentID.ToString()
            }).ToList();

            var model = new DodajParceluVM
            {
                Parcele = parcele,
                Klijenti = klijenti
            };

            return View(model);
        }

        public ActionResult DodajParceluSnimi(DodajParceluVM model)
        {
            //db.Database.ExecuteSqlCommand("INSERT INTO KlijentParcela VALUES({0}, {1}", model.Klijent, model.Parcela);
            foreach (var item in model.Parcela) {
                db.Database.ExecuteSqlCommand("insert into KlijentParcela Values(@KlijentID, @ParcelaID)",
                    new SqlParameter("KlijentID", model.Klijent),
                    new SqlParameter("ParcelaID", item));
            }

            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}