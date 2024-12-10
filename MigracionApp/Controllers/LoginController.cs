using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MigracionApp.Models;

namespace MigracionApp.Controllers
{
    
    public class LoginController : Controller
    {
        private MigracionEntities db = new MigracionEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // Procesa el inicio de sesión
        [HttpPost]
       
        public ActionResult Index(string email, string clave)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(clave))
            {
                ViewBag.Error = "Debe ingresar un email y una clave.";
                return View();
            }

            var usuario = db.USUARIOS.FirstOrDefault(u => u.email == email && u.clave == clave);

            if (usuario != null)
            {
                // Guarda información del usuario en la sesión
                Session["UsuarioId"] = usuario.id;
                Session["Nombre"] = usuario.nombre;
                Session["Rol"] = usuario.rol;

                // Redirije según el rol
                if (usuario.rol == "Administrador")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (usuario.rol == "Usuario")
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Email o clave incorrectos.";
            return View();
        }

        // Cierra la sesión
        public ActionResult Logout()
        {
            Session.Clear();
            ViewBag.Message = "Has cerrado sesión correctamente.";
            return RedirectToAction("Index");
        }
    }
    
}