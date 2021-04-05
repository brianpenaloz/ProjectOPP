using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOPP.Models;

namespace ProjectOPP.Controllers
{
    public class PersonaController : Controller
    {
        readonly Persona p = new Persona();
        readonly Rol r = new Rol();
        readonly Usuario u = new Usuario();

        // GET: Persona
        public ActionResult Index()
        {
            ViewBag.Nombre = ((Persona)Session["User"]).Nombres;

            List<Persona> lista = p.Read();
            return View(lista);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View(p.Read(id));
        }

        // GET: Persona/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Persona());
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            try
            {
                // TODO: Add insert logic here
                p.Create(persona);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(p.Read(id));
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            try
            {
                // TODO: Add update logic here
                p.Update(persona);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            p.Delete(id);
            //return View();
            return RedirectToAction("Index");
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
