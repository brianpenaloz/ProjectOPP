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
            List<Tramite> lstBean = t.Read();
            return View(lstBean);
        }
    }
}