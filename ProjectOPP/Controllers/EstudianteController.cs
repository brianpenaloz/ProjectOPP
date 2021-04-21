using System;
using System.Collections.Generic;
using System.IO;
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

            if(TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Save(Tramite tramite)
        {
            string RutaSitio = Server.MapPath("~/");
            string codigoUsuario = ((Usuario)Session["User"]).Codigo;
            string PathArchivo1 = Path.Combine(RutaSitio + "/Tramites/" + codigoUsuario + ".png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Tramites/archivo2.png");

            if (!ModelState.IsValid)
            {
                return View("Index", tramite);
            }

            //tramite.Archivo1.SaveAs(PathArchivo1);
            //tramite.Archivo2.SaveAs(PathArchivo2);

            @TempData["Message"] = "Se cargaron los archivos";
            return RedirectToAction("Index");
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
                tramite.ID_Usuario = ((Usuario)Session["User"]).ID;
                tramite.ID_Estado = 1;
                tramite.Tramit = "CARTA DE PRESENTACION - PRACTICA PRE PROFESIONAL";
                tramite.DependenciaReferencia = "Facultad de Ingenieria Industrial y de Sistemas";
                t.Create(tramite);



                string RutaSitio = Server.MapPath("~/");
                string codigoUsuario = ((Usuario)Session["User"]).Codigo;
                string PathArchivo1 = Path.Combine(RutaSitio + "/Tramites/" + codigoUsuario + ".png");
                string PathArchivo2 = Path.Combine(RutaSitio + "/Tramites/archivo2.png");

                if (!ModelState.IsValid)
                {
                    return View("Index", tramite);
                }

                //tramite.Archivo1.SaveAs(PathArchivo1);
                //tramite.Archivo2.SaveAs(PathArchivo2);

                @TempData["Message"] = "Se cargaron los archivos";



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}