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
    public class LOGINsController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: LOGINs
        public ActionResult Index()
        {
            var lOGIN = db.LOGIN.Include(l => l.USUARIOS);
            return View(lOGIN.ToList());
        }

        // GET: LOGINs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // GET: LOGINs/Create
        public ActionResult Create()
        {
            ViewBag.usuario_id = new SelectList(db.USUARIOS, "id", "nombre");
            return View();
        }

        // POST: LOGINs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usuario_id,email,clave,ultimo_acceso")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.LOGIN.Add(lOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuario_id = new SelectList(db.USUARIOS, "id", "nombre", lOGIN.usuario_id);
            return View(lOGIN);
        }

        // GET: LOGINs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuario_id = new SelectList(db.USUARIOS, "id", "nombre", lOGIN.usuario_id);
            return View(lOGIN);
        }

        // POST: LOGINs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usuario_id,email,clave,ultimo_acceso")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuario_id = new SelectList(db.USUARIOS, "id", "nombre", lOGIN.usuario_id);
            return View(lOGIN);
        }

        // GET: LOGINs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOGIN lOGIN = db.LOGIN.Find(id);
            db.LOGIN.Remove(lOGIN);
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
