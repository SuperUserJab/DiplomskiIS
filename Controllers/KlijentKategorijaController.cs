using DiplomskiISpoljoprivreda.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomskiISpoljoprivreda.Controllers
{
    public class KlijentKategorijaController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        // GET: KlijentKategorija
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DodajKategoriju()
        {
            var klijenti = db.Klijent.Select(k => new SelectListItem
            {
                Text = k.Ime + " " + k.Prezime,
                Value = k.KlijentID.ToString()
            }).ToList();

            var kategorije = db.Kategorija.Select(k => new SelectListItem
            {
                Text = k.Vrsta,
                Value = k.KategorijaID.ToString()
            }).ToList();

            var model = new DodajKategorijuVM
            {
                Kategorije = kategorije,
                Klijenti = klijenti
            };

            return View(model);
        }

        public ActionResult DodajKategorijuSnimi(DodajKategorijuVM model)
        {
            //db.Database.ExecuteSqlCommand("INSERT INTO KlijentParcela VALUES({0}, {1}", model.Klijent, model.Parcela);
            foreach (var item in model.Kategorije)
            {
                db.Database.ExecuteSqlCommand("insert into KlijentKategorija Values(@KlijentID, @KategorijaID)",
                    new SqlParameter("KlijentID", model.Klijent),
                    new SqlParameter("KategorijaID", item));
            }


            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}