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
        // GET: Administrador
        public ActionResult Index()
        {
            //ViewBag.Nombre = ((Usuario)Session["User"]).Nombres;
            return View();
        }
    }
}