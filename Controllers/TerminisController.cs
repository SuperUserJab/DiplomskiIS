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
    public class TerminisController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();
        [Authorize(Users = "admin@mail.com")]

        // GET: Terminis
        public ActionResult Index()
        {
            var termini = db.Termini.Include(t => t.Korisnik);
            return View(termini.ToList());
        }

        // GET: Terminis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Termini.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            return View(termini);
        }

        // GET: Terminis/Create
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime");
            return View();
        }

        // POST: Terminis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminID,Ime,Prezime,Mail,Telefon,Svrha,Opis,KorisnikID")] Termini termini)
        {
            if (ModelState.IsValid)
            {
                db.Termini.Add(termini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime", termini.KorisnikID);
            return View(termini);
        }
        [Authorize(Users = "admin@mail.com")]

        // GET: Terminis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Termini.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime", termini.KorisnikID);
            return View(termini);
        }

        // POST: Terminis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminID,Ime,Prezime,Mail,Telefon,Svrha,Opis,KorisnikID")] Termini termini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnik, "KorisnikID", "Ime", termini.KorisnikID);
            return View(termini);
        }
        [Authorize(Users = "admin@mail.com")]

        // GET: Terminis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Termini.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            return View(termini);
        }

        // POST: Terminis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termini termini = db.Termini.Find(id);
            db.Termini.Remove(termini);
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
