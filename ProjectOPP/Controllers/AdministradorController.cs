using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOPP.Models;

namespace ProjectOPP.Controllers
{
    public class AdministradorController : Controller
    {
        readonly Tramite t = new Tramite();

        // GET: Administrador
        public ActionResult Index()
        {
            ViewBag.Nombre = ((Usuario)Session["User"]).Nombres;
            return View();
        }

        public ActionResult TramiteList()
        {
            ViewBag.Nombre = ((Usuario)Session["User"]).Nombres;

            List<Tramite> lstBean = t.Read();
            return View(lstBean);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Nombre = ((Usuario)Session["User"]).Nombres;

            return View(t.Read(id));
        }

        public ActionResult GeneratePDF(int id)
        {
            t.CreatePDFOneDocument(t.Read(id));
            return View("Index");
        }
    }
}