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
    public class FinansijesController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        // GET: Finansijes
        public ActionResult Index()
        {
            return View(db.Finansije.ToList());
        }

        // GET: Finansijes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finansije finansije = db.Finansije.Find(id);
            if (finansije == null)
            {
                return HttpNotFound();
            }
            return View(finansije);
        }

        // GET: Finansijes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Finansijes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinansijeID,Prihodi,Rashodi,FinansijskiRezultat,Godina")] Finansije finansije)
        {
            if (ModelState.IsValid)
            {
                db.Finansije.Add(finansije);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finansije);
        }

        // GET: Finansijes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finansije finansije = db.Finansije.Find(id);
            if (finansije == null)
            {
                return HttpNotFound();
            }
            return View(finansije);
        }

        // POST: Finansijes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinansijeID,Prihodi,Rashodi,FinansijskiRezultat,Godina")] Finansije finansije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finansije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finansije);
        }

        // GET: Finansijes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finansije finansije = db.Finansije.Find(id);
            if (finansije == null)
            {
                return HttpNotFound();
            }
            return View(finansije);
        }

        // POST: Finansijes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Finansije finansije = db.Finansije.Find(id);
            db.Finansije.Remove(finansije);
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
