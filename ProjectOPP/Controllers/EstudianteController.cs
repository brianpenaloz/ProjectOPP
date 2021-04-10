using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOPP.Models;

namespace ProjectOPP.Controllers
{
    public class EstudianteController : Controller
    {
        readonly Tramite t = new Tramite();

        // GET: Estudiante
        public ActionResult Index()
        {
            ViewBag.Nombre = ((Usuario)Session["User"]).Nombres;
            return View();
        }

        public ActionResult Tramite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tramite(Tramite tramite)
        {
            try
            {
                tramite.Usuario = ((Usuario)Session["User"]).ID;
                t.Create(tramite);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}