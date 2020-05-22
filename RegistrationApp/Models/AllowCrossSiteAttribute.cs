using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationApp.Models
{

    public class AllowCrossSiteAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
         
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Methods","GET, POST, PATCH, PUT, DELETE, OPTIONS");
            string rqstMethod = HttpContext.Current.Request.Headers["Access-Control-Request-Method"];
            //if (rqstMethod == "OPTIONS" || rqstMethod == "POST")
            //{
            //    filterContext.RequestContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //    filterContext.RequestContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With, Accept, Access-Control-Allow-Origin, Content-Type");
            //}

             if (filterContext.HttpContext.Request.HttpMethod == "OPTIONS")
             {
                filterContext.HttpContext.Response.Flush();
            //    //filterContext.HttpContext.Response.End();
             }
            base.OnActionExecuting(filterContext);
        }

    }
}