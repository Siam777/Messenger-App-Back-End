using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationApp.Models
{
    public class AccessClassAttribute: ActionFilterAttribute
    {
         public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequest request = HttpContext.Current.Request;
            HttpResponse response = HttpContext.Current.Response;

            // check for preflight request
            if (request.Headers.AllKeys.Contains("Origin") && request.HttpMethod == "OPTIONS")
            {
                response.AppendHeader("Access-Control-Allow-Origin", "*");
                response.AppendHeader("Access-Control-Allow-Credentials", "true");
                response.AppendHeader("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE");
                response.AppendHeader("Access-Control-Allow-Headers", "*");
                response.End();
            }
            else
            {
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();

                response.AppendHeader("Access-Control-Allow-Origin", "*");
                response.AppendHeader("Access-Control-Allow-Credentials", "true");
                if (request.HttpMethod == "POST")
                {
                    response.AppendHeader("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE");
                    response.AppendHeader("Access-Control-Allow-Headers", "*");
                }

                base.OnActionExecuting(filterContext);
            }
        }
    }
}