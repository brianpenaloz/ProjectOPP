using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOPP.Models;

namespace ProjectOPP.Controllers
{
    public class AccesoController : Controller
    {
        Usuario u = new Usuario();

        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string clave)
        {
            int rol = 1;
            try
            {
                Usuario Existe = u.Login(usuario, clave, rol);

                if(Existe == null)
                {
                    ViewBag.Error = "Usuario o clave invalido";
                    return View();
                }

                Session["User"] = Existe;

                return RedirectToAction("Index", "Persona");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult Logup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logup(string usuario, string clave)
        {
            try
            {
                Usuario Existe = u.Logup(usuario, clave);

                if (Existe == null)
                {
                    ViewBag.Error = "Usuario o clave invalido";
                    return View();
                }

                Session["User"] = Existe;

                return RedirectToAction("Index", "Persona");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string usuario, string clave)
        {
            int rol = 1;
            try
            {
                Usuario Existe = u.Login(usuario, clave, rol);

                if (Existe == null)
                {
                    ViewBag.Error = "Usuario o clave invalido";
                    return View();
                }

                Session["User"] = Existe;

                return RedirectToAction("Index", "Persona");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}