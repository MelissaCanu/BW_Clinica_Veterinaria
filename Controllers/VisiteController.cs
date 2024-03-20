using BW_Clinica_Veterinaria.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class VisiteController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Visite

        //searchString è il parametro che viene passato dal form di ricerca per filtrare le visite per nome dell'animale 
        public ActionResult Index(string searchString)
        {
            //from serve per selezionare le visite e includere anche i dati dell'animale
            //è una join tra le tabelle Visite e Animali 
            var visite = from v in db.Visite.Include(v => v.Animali)
                         select v;

            //se è stato inserito un valore nel campo di ricerca, filtro le visite per nome dell'animale
            if (!string.IsNullOrEmpty(searchString))
            {
                visite = visite.Where(v => v.Animali.Nome.Contains(searchString));
            }

            return View(visite.ToList());
        }

        // GET: Visite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visite visite = db.Visite.Find(id);
            if (visite == null)
            {
                return HttpNotFound();
            }
            return View(visite);
        }

        //Cronistoria

        public ActionResult Cronistoria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var visite = db.Visite.Where(v => v.AnimaleID == id).OrderByDescending(v => v.Data).ToList();
            if (visite == null)
            {
                return HttpNotFound();
            }
            return View(visite);

        }

        // GET: Visite/Create
        public ActionResult Create()
        {
            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome");
            return View();
        }

        // POST: Visite/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitaID,AnimaleID,Data,Esame,Cura")] Visite visite)
        {
            if (ModelState.IsValid)
            {
                db.Visite.Add(visite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome", visite.AnimaleID);
            return View(visite);
        }

        // GET: Visite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visite visite = db.Visite.Find(id);
            if (visite == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome", visite.AnimaleID);
            return View(visite);
        }

        // POST: Visite/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitaID,AnimaleID,Data,Esame,Cura")] Visite visite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimaleID = new SelectList(db.Animali, "AnimaleID", "Nome", visite.AnimaleID);
            return View(visite);
        }

        // GET: Visite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visite visite = db.Visite.Find(id);
            if (visite == null)
            {
                return HttpNotFound();
            }
            return View(visite);
        }

        // POST: Visite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visite visite = db.Visite.Find(id);
            db.Visite.Remove(visite);
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
