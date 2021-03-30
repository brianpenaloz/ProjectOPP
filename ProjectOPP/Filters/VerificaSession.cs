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

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                usuario = (Usuario)HttpContext.Current.Session["User"];

                if (usuario == null && !(filterContext.ActionDescriptor.ActionName == "Index" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home"))
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
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}