using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2015104916.Entities.Entities;
using _2015104916.Persistence;

namespace _2015104916.MVC.Controllers
{
    public class CinturonController : Controller
    {
        private _2015147396DbContext db = new _2015147396DbContext();

        // GET: Cinturon
        public ActionResult Index()
        {
            var Cinturon = db.Cinturon.Include(c => c.Asiento);
            return View(Cinturon.ToList());
        }

        // GET: Cinturon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = db.Cinturon.Find(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // GET: Cinturon/Create
        public ActionResult Create()
        {
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerie");
            return View();
        }

        // POST: Cinturon/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinturonId,NumSerie,Metraje,AsientoId")] Cinturon cinturon)
        {
            if (ModelState.IsValid)
            {
                db.Cinturon.Add(cinturon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerie", cinturon.AsientoId);
            return View(cinturon);
        }

        // GET: Cinturon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = db.Cinturon.Find(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerie", cinturon.AsientoId);
            return View(cinturon);
        }

        // POST: Cinturon/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinturonId,NumSerie,Metraje,AsientoId")] Cinturon cinturon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinturon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerie", cinturon.AsientoId);
            return View(cinturon);
        }

        // GET: Cinturon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = db.Cinturon.Find(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // POST: Cinturon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinturon cinturon = db.Cinturon.Find(id);
            db.Cinturon.Remove(cinturon);
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
