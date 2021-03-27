using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOPP.Models;
using ProjectOPP.Controllers;

namespace ProjectOPP.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Usuario usuario;
        //private string usuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                usuario = (Usuario)HttpContext.Current.Session["User"];
                //usuario = (string)HttpContext.Current.Session["User"];

                if (usuario == null)
                {
                    if(filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }
                }
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }
        }
    }
}