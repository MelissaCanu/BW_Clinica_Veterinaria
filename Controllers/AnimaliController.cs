using BW_Clinica_Veterinaria.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class AnimaliController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Animali
        public ActionResult Index()
        {
            var animali = db.Animali.Include(a => a.Proprietari);
            return View(animali.ToList());
        }

        // GET: Animali/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animali animali = db.Animali.Find(id);
            if (animali == null)
            {
                return HttpNotFound();
            }
            return View(animali);
        }

        // GET: Animali/Create
        public ActionResult Create()
        {
            ViewBag.ProprietarioID = new SelectList(db.Proprietari, "ProprietarioID", "Nome");
            return View();
        }

        // POST: Animali/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimaleID,Nome,Tipo,ColoreManto,DataNascita,HasChip,NChip,ProprietarioID,Foto")] Animali animali, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                file.SaveAs(path); 
                animali.Foto = "/Content/Images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                //animali.DataReg = DateTime.Now;
                db.Animali.Add(animali);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProprietarioID = new SelectList(db.Proprietari, "ProprietarioID", "Nome", animali.ProprietarioID);
            return View(animali);
        }


        // GET: Animali/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animali animali = db.Animali.Find(id);
            if (animali == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProprietarioID = new SelectList(db.Proprietari, "ProprietarioID", "Nome", animali.ProprietarioID);
            return View(animali);
        }

        // POST: Animali/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimaleID,DataReg,Nome,Tipo,ColoreManto,DataNascita,HasChip,NChip,ProprietarioID,Foto")] Animali animali)
        {
            if (ModelState.IsValid)
            {

                db.Entry(animali).State = EntityState.Modified;
                db.Entry(animali).Property(x => x.DataReg).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProprietarioID = new SelectList(db.Proprietari, "ProprietarioID", "Nome", animali.ProprietarioID);
            return View(animali);
        }

        // GET: Animali/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animali animali = db.Animali.Find(id);
            if (animali == null)
            {
                return HttpNotFound();
            }
            return View(animali);
        }

        // POST: Animali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animali animali = db.Animali.Find(id);
            db.Animali.Remove(animali);
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
