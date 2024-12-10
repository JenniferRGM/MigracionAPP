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
    public class GENEROSController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: GENEROS
        public ActionResult Index()
        {
            return View(db.GENEROS.ToList());
        }

        // GET: GENEROS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENEROS gENEROS = db.GENEROS.Find(id);
            if (gENEROS == null)
            {
                return HttpNotFound();
            }
            return View(gENEROS);
        }

        // GET: GENEROS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GENEROS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] GENEROS gENEROS)
        {
            if (ModelState.IsValid)
            {
                db.GENEROS.Add(gENEROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gENEROS);
        }

        // GET: GENEROS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENEROS gENEROS = db.GENEROS.Find(id);
            if (gENEROS == null)
            {
                return HttpNotFound();
            }
            return View(gENEROS);
        }

        // POST: GENEROS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] GENEROS gENEROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENEROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gENEROS);
        }

        // GET: GENEROS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENEROS gENEROS = db.GENEROS.Find(id);
            if (gENEROS == null)
            {
                return HttpNotFound();
            }
            return View(gENEROS);
        }

        // POST: GENEROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENEROS gENEROS = db.GENEROS.Find(id);
            db.GENEROS.Remove(gENEROS);
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
