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
    //[Authorize(Roles = "User")]
    public class VijestisController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        // GET: Vijestis
        public ActionResult Index()
        {
            var vijesti = db.Vijesti.Include(v => v.Uloga);
            return View(vijesti.ToList());
        }

        // GET: Vijestis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vijesti vijesti = db.Vijesti.Find(id);
            if (vijesti == null)
            {
                return HttpNotFound();
            }
            return View(vijesti);
        }

        // GET: Vijestis/Create
        public ActionResult Create()
        {
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv");
            return View();
        }

        // POST: Vijestis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VijestID,Naslov,Opis,Datum,UlogaID")] Vijesti vijesti)
        {
            if (ModelState.IsValid)
            {
                db.Vijesti.Add(vijesti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv", vijesti.UlogaID);
            return View(vijesti);
        }


        // GET: Vijestis/Edit/5
        [Authorize(Users = "admin@mail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vijesti vijesti = db.Vijesti.Find(id);
            if (vijesti == null)
            {
                return HttpNotFound();
            }
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv", vijesti.UlogaID);
            return View(vijesti);
        }

        // POST: Vijestis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VijestID,Naslov,Opis,Datum,UlogaID")] Vijesti vijesti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vijesti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UlogaID = new SelectList(db.Uloga, "UlogaID", "Naziv", vijesti.UlogaID);
            return View(vijesti);
        }

        // GET: Vijestis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vijesti vijesti = db.Vijesti.Find(id);
            if (vijesti == null)
            {
                return HttpNotFound();
            }
            return View(vijesti);
        }

        // POST: Vijestis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vijesti vijesti = db.Vijesti.Find(id);
            db.Vijesti.Remove(vijesti);
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
