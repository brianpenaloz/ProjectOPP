﻿using System;
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
        public ActionResult Login(string correo, string clave)
        {
            int rol = 2;
            try
            {
                if (correo.Trim() == "" || clave.Trim() == "")
                {
                    ViewBag.Error = "correo o clave invalido";
                    return View();
                }
                else
                {
                    Usuario existe = u.Login(correo, clave, rol);

                    if (existe == null)
                    {
                        ViewBag.Error = "correo o clave invalido";
                        return View();
                    }

                    Session["User"] = existe;

                    return RedirectToAction("Index", "Estudiante");
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
        public ActionResult Logup(Usuario usuario)
        {
            try
            {
                usuario.ID_Rol = 2;

                u.Logup(usuario);

                Session["User"] = usuario;

                return RedirectToAction("Index", "Estudiante");
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
        public ActionResult LoginAdmin(string correo, string clave)
        {
            int rol = 1;
            try
            {
                Usuario existe = u.Login(correo, clave, rol);

                if (existe == null)
                {
                    ViewBag.Error = "correo o clave invalido";
                    return View();
                }

                Session["User"] = existe;

                return RedirectToAction("Index", "Administrador");
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