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
    public class MjestoesController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        // GET: Mjestoes
        public ActionResult Index()
        {
            return View(db.Mjesto.ToList());
        }

        // GET: Mjestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjesto mjesto = db.Mjesto.Find(id);
            if (mjesto == null)
            {
                return HttpNotFound();
            }
            return View(mjesto);
        }

        // GET: Mjestoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mjestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MjestoID,Naziv,Detalji")] Mjesto mjesto)
        {
            if (ModelState.IsValid)
            {
                db.Mjesto.Add(mjesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mjesto);
        }

        // GET: Mjestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjesto mjesto = db.Mjesto.Find(id);
            if (mjesto == null)
            {
                return HttpNotFound();
            }
            return View(mjesto);
        }

        // POST: Mjestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MjestoID,Naziv,Detalji")] Mjesto mjesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mjesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mjesto);
        }

        // GET: Mjestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjesto mjesto = db.Mjesto.Find(id);
            if (mjesto == null)
            {
                return HttpNotFound();
            }
            return View(mjesto);
        }

        // POST: Mjestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mjesto mjesto = db.Mjesto.Find(id);
            db.Mjesto.Remove(mjesto);
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
