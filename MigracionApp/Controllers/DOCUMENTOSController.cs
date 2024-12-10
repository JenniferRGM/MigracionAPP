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
    public class DOCUMENTOSController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: DOCUMENTOS
        public ActionResult Index()
        {
            var dOCUMENTOS = db.DOCUMENTOS.Include(d => d.ESTADOS).Include(d => d.PASAJEROS);
            return View(dOCUMENTOS.ToList());
        }

        // GET: DOCUMENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTOS dOCUMENTOS = db.DOCUMENTOS.Find(id);
            if (dOCUMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTOS);
        }

        // GET: DOCUMENTOS/Create
        public ActionResult Create()
        {
            ViewBag.id_estado = new SelectList(db.ESTADOS, "id", "descripcion");
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre");
            return View();
        }

        // POST: DOCUMENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipo_documento,numero_documento,fecha_expiracion,id_estado,id_viajero")] DOCUMENTOS dOCUMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.DOCUMENTOS.Add(dOCUMENTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado = new SelectList(db.ESTADOS, "id", "descripcion", dOCUMENTOS.id_estado);
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre", dOCUMENTOS.id_viajero);
            return View(dOCUMENTOS);
        }

        // GET: DOCUMENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTOS dOCUMENTOS = db.DOCUMENTOS.Find(id);
            if (dOCUMENTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado = new SelectList(db.ESTADOS, "id", "descripcion", dOCUMENTOS.id_estado);
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre", dOCUMENTOS.id_viajero);
            return View(dOCUMENTOS);
        }

        // POST: DOCUMENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipo_documento,numero_documento,fecha_expiracion,id_estado,id_viajero")] DOCUMENTOS dOCUMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado = new SelectList(db.ESTADOS, "id", "descripcion", dOCUMENTOS.id_estado);
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre", dOCUMENTOS.id_viajero);
            return View(dOCUMENTOS);
        }

        // GET: DOCUMENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTOS dOCUMENTOS = db.DOCUMENTOS.Find(id);
            if (dOCUMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTOS);
        }

        // POST: DOCUMENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCUMENTOS dOCUMENTOS = db.DOCUMENTOS.Find(id);
            db.DOCUMENTOS.Remove(dOCUMENTOS);
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
