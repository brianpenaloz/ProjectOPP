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
        readonly Usuario u = new Usuario();
        readonly Persona p = new Persona();

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
                if (usuario.Trim() == "" || clave.Trim() == "")
                {
                    ViewBag.Error = "Usuario o clave invalido";
                    return View();
                }
                else
                {
                    Usuario Existe = u.Login(usuario, clave, rol);

                    if (Existe == null)
                    {
                        ViewBag.Error = "Usuario o clave invalido";
                        return View();
                    }

                    Session["User"] = Existe;
                    Session["Pers"] = p.Read(Existe.Persona);

                    return RedirectToAction("Index", "Persona");
                }
            }
            catch (Exception e)
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
        public ActionResult Logup(string Nombres, string Apellidos, string Correo, DateTime FecNacimiento, string Usuario, string Clave)
        {
            try
            {
                Persona persona = new Persona
                {
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    Correo = Correo,
                    FecNacimiento = FecNacimiento
                };

                p.Create(persona);

                Usuario usuario = new Usuario
                {
                    User = Usuario,
                    Clave = Clave,
                    Persona = p.GetLastId(),
                    Rol = 1
                };

                u.Create(usuario);

                Session["User"] = usuario;
                Session["Pers"] = persona;

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
            int rol = 2;
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

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }

}