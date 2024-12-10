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
    public class VIAJES_TRANSITO_MIGRACIONController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: VIAJES_TRANSITO_MIGRACION
        public ActionResult Index()
        {
            var vIAJES_TRANSITO_MIGRACION = db.VIAJES_TRANSITO_MIGRACION.Include(v => v.PASAJEROS).Include(v => v.USUARIOS);
            return View(vIAJES_TRANSITO_MIGRACION.ToList());
        }

        // GET: VIAJES_TRANSITO_MIGRACION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJES_TRANSITO_MIGRACION vIAJES_TRANSITO_MIGRACION = db.VIAJES_TRANSITO_MIGRACION.Find(id);
            if (vIAJES_TRANSITO_MIGRACION == null)
            {
                return HttpNotFound();
            }
            return View(vIAJES_TRANSITO_MIGRACION);
        }

        // GET: VIAJES_TRANSITO_MIGRACION/Create
        public ActionResult Create()
        {
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre");
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id", "nombre");
            return View();
        }

        // POST: VIAJES_TRANSITO_MIGRACION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_viajero,fecha,destino,origen,tipo_solicitud,motivo_viaje,id_usuario")] VIAJES_TRANSITO_MIGRACION vIAJES_TRANSITO_MIGRACION)
        {
            if (ModelState.IsValid)
            {
                db.VIAJES_TRANSITO_MIGRACION.Add(vIAJES_TRANSITO_MIGRACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre", vIAJES_TRANSITO_MIGRACION.id_viajero);
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id", "nombre", vIAJES_TRANSITO_MIGRACION.id_usuario);
            return View(vIAJES_TRANSITO_MIGRACION);
        }

        // GET: VIAJES_TRANSITO_MIGRACION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJES_TRANSITO_MIGRACION vIAJES_TRANSITO_MIGRACION = db.VIAJES_TRANSITO_MIGRACION.Find(id);
            if (vIAJES_TRANSITO_MIGRACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre", vIAJES_TRANSITO_MIGRACION.id_viajero);
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id", "nombre", vIAJES_TRANSITO_MIGRACION.id_usuario);
            return View(vIAJES_TRANSITO_MIGRACION);
        }

        // POST: VIAJES_TRANSITO_MIGRACION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_viajero,fecha,destino,origen,tipo_solicitud,motivo_viaje,id_usuario")] VIAJES_TRANSITO_MIGRACION vIAJES_TRANSITO_MIGRACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIAJES_TRANSITO_MIGRACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_viajero = new SelectList(db.PASAJEROS, "id", "nombre", vIAJES_TRANSITO_MIGRACION.id_viajero);
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id", "nombre", vIAJES_TRANSITO_MIGRACION.id_usuario);
            return View(vIAJES_TRANSITO_MIGRACION);
        }

        // GET: VIAJES_TRANSITO_MIGRACION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJES_TRANSITO_MIGRACION vIAJES_TRANSITO_MIGRACION = db.VIAJES_TRANSITO_MIGRACION.Find(id);
            if (vIAJES_TRANSITO_MIGRACION == null)
            {
                return HttpNotFound();
            }
            return View(vIAJES_TRANSITO_MIGRACION);
        }

        // POST: VIAJES_TRANSITO_MIGRACION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIAJES_TRANSITO_MIGRACION vIAJES_TRANSITO_MIGRACION = db.VIAJES_TRANSITO_MIGRACION.Find(id);
            db.VIAJES_TRANSITO_MIGRACION.Remove(vIAJES_TRANSITO_MIGRACION);
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
