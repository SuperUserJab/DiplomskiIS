using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomskiISpoljoprivreda;

namespace DiplomskiISpoljoprivreda.Controllers
{
    public class KorisniksController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        // GET: Korisniks
        public ActionResult Index()
        {
            var korisnik = db.Korisnik.Include(k => k.Izvjestaj).Include(k => k.Uloga);
            return View(korisnik.ToList());
        }

        // GET: Korisniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisniks/Create
        public ActionResult Create()
        {
            ViewBag.IzvjestajID = new SelectList(db.Izvjestaj, "IzvjestajID", "Tip");
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv");
            return View();
        }

        // POST: Korisniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisnikID,Ime,Prezime,KorisnickoIme,Email,Lozinka,UlogaID,IzvjestajID")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisnik.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IzvjestajID = new SelectList(db.Izvjestaj, "IzvjestajID", "Tip", korisnik.IzvjestajID);
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv", korisnik.UlogaID);
            return View(korisnik);
        }

        // GET: Korisniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.IzvjestajID = new SelectList(db.Izvjestaj, "IzvjestajID", "Tip", korisnik.IzvjestajID);
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv", korisnik.UlogaID);
            return View(korisnik);
        }

        // POST: Korisniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KorisnikID,Ime,Prezime,KorisnickoIme,Email,Lozinka,UlogaID,IzvjestajID")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IzvjestajID = new SelectList(db.Izvjestaj, "IzvjestajID", "Tip", korisnik.IzvjestajID);
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv", korisnik.UlogaID);
            return View(korisnik);
        }

        // GET: Korisniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.Korisnik.Find(id);
            db.Korisnik.Remove(korisnik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
