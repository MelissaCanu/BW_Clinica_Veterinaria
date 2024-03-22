using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BW_Clinica_Veterinaria.Models;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class RicoveriController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Ricoveri
        public ActionResult Index()
        {
            var ricoveri = db.Ricoveri.Include(r => r.Animali);
            return View(ricoveri.ToList());
        }

        // GET: Ricoveri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ricoveri ricoveri = db.Ricoveri.Find(id);
            if (ricoveri == null)
            {
                return HttpNotFound();
            }
            return View(ricoveri);
        }

        // GET: Ricoveri/Create
        public ActionResult Create()
        {
            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome");
            return View();
        }

        // POST: Ricoveri/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RicoveroID,DataIN,DataOUT,AnimaleID")] Ricoveri ricoveri)
        {
            if (ModelState.IsValid)
            {
                db.Ricoveri.Add(ricoveri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome", ricoveri.AnimaleID);
            return View(ricoveri);
        }

        // GET: Ricoveri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ricoveri ricoveri = db.Ricoveri.Find(id);
            if (ricoveri == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome", ricoveri.AnimaleID);
            return View(ricoveri);
        }

        // POST: Ricoveri/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RicoveroID,DataIN,DataOUT,AnimaleID,Costo")] Ricoveri ricoveri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ricoveri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome", ricoveri.AnimaleID);
            return View(ricoveri);
        }

        // GET: Ricoveri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ricoveri ricoveri = db.Ricoveri.Find(id);
            if (ricoveri == null)
            {
                return HttpNotFound();
            }
            return View(ricoveri);
        }

        // POST: Ricoveri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ricoveri ricoveri = db.Ricoveri.Find(id);
            db.Ricoveri.Remove(ricoveri);
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
