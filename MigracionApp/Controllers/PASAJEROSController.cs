using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace MigracionApp.Controllers
{
    public class PASAJEROSController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: PASAJEROS
        
        public ActionResult Index()
        {
            var pASAJEROS = db.PASAJEROS.Include(p => p.GENEROS);
            return View(pASAJEROS.ToList());
        }

        // GET: PASAJEROS/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PASAJEROS pASAJEROS = db.PASAJEROS.Find(id);
            if (pASAJEROS == null)
            {
                return HttpNotFound();
            }
            return View(pASAJEROS);
        }

        // GET: PASAJEROS/Create
        
        public ActionResult Create()
        {
            ViewBag.genero_fk = new SelectList(db.GENEROS, "id", "descripcion");
            return View();
        }

        // POST: PASAJEROS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "id,nombre,segundo_nombre,apellido1,apellido2,fecha_nacimiento,nacionalidad,correo_electronico,genero_fk")] PASAJEROS pASAJEROS)
        {
            if (ModelState.IsValid)
            {
                db.PASAJEROS.Add(pASAJEROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.genero_fk = new SelectList(db.GENEROS, "id", "descripcion", pASAJEROS.genero_fk);
            return View(pASAJEROS);
        }

        // GET: PASAJEROS/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PASAJEROS pASAJEROS = db.PASAJEROS.Find(id);
            if (pASAJEROS == null)
            {
                return HttpNotFound();
            }
            ViewBag.genero_fk = new SelectList(db.GENEROS, "id", "descripcion", pASAJEROS.genero_fk);
            return View(pASAJEROS);
        }

        // POST: PASAJEROS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include = "id,nombre,segundo_nombre,apellido1,apellido2,fecha_nacimiento,nacionalidad,correo_electronico,genero_fk")] PASAJEROS pASAJEROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pASAJEROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.genero_fk = new SelectList(db.GENEROS, "id", "descripcion", pASAJEROS.genero_fk);
            return View(pASAJEROS);
        }

        // GET: PASAJEROS/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PASAJEROS pASAJEROS = db.PASAJEROS.Find(id);
            if (pASAJEROS == null)
            {
                return HttpNotFound();
            }
            return View(pASAJEROS);
        }

        // POST: PASAJEROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            PASAJEROS pASAJEROS = db.PASAJEROS.Find(id);
            db.PASAJEROS.Remove(pASAJEROS);
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
