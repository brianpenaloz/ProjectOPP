using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOPP.Models;


using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using iText.IO.Image;
using System.IO;

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
            ViewBag.Nombre = ((Usuario)Session["User"]).Nombres;

            //t.CreatePDFOneDocument(t.Read(id));
            //t.GenerarPDFDescargado();

            //Lo abre visualmente en una pestaña en el navegador
            //return new FileContentResult(t.GenerarPDFDescargable(), "application/pdf");


            DateTime FechaActual = DateTime.UtcNow;
            TimeZoneInfo serverZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(FechaActual, serverZone);

            string danho = currentDateTime.ToString("yyyy");
            string dmes = currentDateTime.ToString("MM");
            string ddia = currentDateTime.ToString("dd");
            string dhora = currentDateTime.ToString("hh");
            string dminuto = currentDateTime.ToString("mm");
            string dsegundo = currentDateTime.ToString("ss");
            string fechacompleta = danho + dmes + ddia + dhora + dminuto + dsegundo;

            Tramite tttt = t.Read(id);

            //Lo descarga como un PDF
            return File(t.CreatePDFOneDocument(tttt), "application/pdf", "CartaDePresentacion-" + tttt.usuario.Codigo + "-" + fechacompleta + ".pdf");

            //return View("Index");
        }
    }
}