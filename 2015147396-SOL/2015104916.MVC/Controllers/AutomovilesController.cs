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
    public class AutomovilesController : Controller
    {
        private _2015147396DbContext db = new _2015147396DbContext();
        public ActionResult Index()
        {
            var automoviles = db.Automoviles.Include(c => c.Ensambladora).Include(c => c.Parabrisas).Include(c => c.Propietario).Include(c => c.Volante);
            return View(automoviles.ToList());
        }

        // GET: Carros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automoviles = db.Automoviles.Find(id);
            if (automoviles == null)
            {
                return HttpNotFound();
            }
            return View(automoviles);
        }

        // GET: Carros/Create
        public ActionResult Create()
        {
            ViewBag.idEnsambladora = new SelectList(db.Ensambladoras, "idEnsambladora", "Nombre");
            ViewBag.idCarro = new SelectList(db.Parabrisas, "idParabrisas", "NumSerie");
            ViewBag.idCarro = new SelectList(db.Propietarios, "PropietarioId", "Dni");
            ViewBag.idCarro = new SelectList(db.Volantes, "VolanteId", "NumSerie");
            return View();
        }

        // POST: Carros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCarro,NumSerieMotor,NumSerieChasis,idEnsambladora,TipoCarro,TipoAuto")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Automoviles.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEnsambladora = new SelectList(db.Ensambladoras, "idEnsambladora", "Nombre", automovil.idEnsambladora);
            ViewBag.idCarro = new SelectList(db.Parabrisas, "idParabrisas", "NumSerie", automovil.idCarro);
            ViewBag.idCarro = new SelectList(db.Propietarios, "PropietarioId", "Dni", automovil.idCarro);
            ViewBag.idCarro = new SelectList(db.Volantes, "VolanteId", "NumSerie", automovil.idCarro);
            return View(automovil);
        }

        // GET: Carros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automovil = db.Automoviles.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEnsambladora = new SelectList(db.Ensambladoras, "idEnsambladora", "Nombre", automovil.idEnsambladora);
            ViewBag.idCarro = new SelectList(db.Parabrisas, "idParabrisas", "NumSerie", automovil.idCarro);
            ViewBag.idCarro = new SelectList(db.Propietarios, "PropietarioId", "Dni", automovil.idCarro);
            ViewBag.idCarro = new SelectList(db.Volantes, "VolanteId", "NumSerie", automovil.idCarro);
            return View(automovil);
        }

        // POST: Carros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCarro,NumSerieMotor,NumSerieChasis,idEnsambladora,TipoCarro,TipoAuto")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEnsambladora = new SelectList(db.Ensambladoras, "idEnsambladora", "Nombre", automovil.idEnsambladora);
            ViewBag.idCarro = new SelectList(db.Parabrisas, "idParabrisas", "NumSerie", automovil.idCarro);
            ViewBag.idCarro = new SelectList(db.Propietarios, "PropietarioId", "Dni", automovil.idCarro);
            ViewBag.idCarro = new SelectList(db.Volantes, "VolanteId", "NumSerie", automovil.idCarro);
            return View(automovil);
        }

        // GET: Carros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro bus = db.Buses.Find(id);
            db.Carros.Remove(bus);
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
