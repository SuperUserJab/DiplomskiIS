using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomskiISpoljoprivreda;
using DiplomskiISpoljoprivreda.Models;
using System.Data.SqlClient;

namespace DiplomskiISpoljoprivreda.Controllers
{
  //[Authorize] - korisnik mora biti logiran, bilo koji korisnik
  //[Authorize(Roles="User")] - korisnik u ulozi User
    public class BrojParcelesController : Controller
    {
        private EvidencijaUdruzenjeEntities db = new EvidencijaUdruzenjeEntities();

        // GET: BrojParceles
        public ActionResult Index()
        {
            return View(db.BrojParcele.ToList());
        }

        // GET: BrojParceles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrojParcele brojParcele = db.BrojParcele.Find(id);
            if (brojParcele == null)
            {
                return HttpNotFound();
            }
            return View(brojParcele);
        }

        // GET: BrojParceles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrojParceles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParcelaID,BrojParcele1,Opis,Kvadratura")] BrojParcele brojParcele)
        {
            if (ModelState.IsValid)
            {
                db.BrojParcele.Add(brojParcele);
                db.SaveChanges();
                //return RedirectToAction("Index");

                return RedirectToAction("OdaberiMjesto", new { @parcelaId = brojParcele.ParcelaID });
            }

            return View(brojParcele);

        }

        // GET: BrojParceles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrojParcele brojParcele = db.BrojParcele.Find(id);
            if (brojParcele == null)
            {
                return HttpNotFound();
            }
            return View(brojParcele);
        }

        // POST: BrojParceles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParcelaID,BrojParcele1,Opis,Kvadratura")] BrojParcele brojParcele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brojParcele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brojParcele);
        }

        // GET: BrojParceles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrojParcele brojParcele = db.BrojParcele.Find(id);
            if (brojParcele == null)
            {
                return HttpNotFound();
            }
            return View(brojParcele);
        }

        // POST: BrojParceles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrojParcele brojParcele = db.BrojParcele.Find(id);
            db.BrojParcele.Remove(brojParcele);
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

        public ActionResult OdaberiMjesto(int parcelaId)
        {
            var mjesta = db.Mjesto.Select(m => new SelectListItem
            {
                Text = m.Naziv,
                Value = m.MjestoID.ToString()
            }).ToList();

            var model = new OdaberiMjestoVM
            {
                Mjesta = mjesta,
                ParcelaId = parcelaId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult OdaberiMjestoSave(OdaberiMjestoVM model)
        {
            int mjestoId = Convert.ToInt32(model.MjestoId);

            int parcelaId = model.ParcelaId;

            db.Database.ExecuteSqlCommand("insert into MjestoParcela Values(@MjestoID, @ParcelaID)",
                    new SqlParameter("MjestoID", mjestoId),
                    new SqlParameter("ParcelaID", parcelaId));

            
            db.SaveChanges(); //mozda i ne treba, nezz

            return RedirectToAction("Index");
        }
    }
}
