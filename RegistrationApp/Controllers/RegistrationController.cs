using RegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
///using System.Web;
using System.Web.Mvc;
//using System.Web.Http;
using Newtonsoft.Json;

namespace RegistrationApp.Controllers
{
    //[AllowCrossSite]
    public class RegistrationController : Controller
    {
        // GET: Registration
        AppContext db = new AppContext();
        public ActionResult Index()
        {
            return View();
        }

        // [AllowCrossSite]
        // [HttpPost]
        //[HttpOptions]
        // [System.Web.Http.HttpGet] 
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Options)]
        [AccessClassAttribute]
        public JsonResult RegistrationSave( RegistrationInfo registration)
        {
           
            if (registration != null)
            {
                //db.RegistrationInfo.Add(registration);
                //db.SaveChanges();
            }
            //ProfileInfo info = new ProfileInfo();
            //var registrationId = db.RegistrationInfo.Max(s => s.Id);
            //info.RegistrationId = registrationId;
            //info.Email = registration.Email;
            //info.UserName = registration.Name;
            //db.ProfileInfo.Add(info);
            //return Json(new { status = "Successfully Registered" }, JsonRequestBehavior.AllowGet);
            return Json(new { status = "Successfully Registered" });
        }

        //[HttpGet]
        //[HttpOptions]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Options)]
        [AccessClassAttribute]
        public JsonResult CheckLogIn(string name,string password)
        {
            var loginInfo = db.RegistrationInfo.Where(x => x.Name == name && x.Password == password).SingleOrDefault();
            if (loginInfo == null)
            {
                return Json(new { status = "Unauthorized" });
            }
            else
            {
                var profileInfo = db.ProfileInfo.Where(x => x.RegistrationId == loginInfo.Id).SingleOrDefault();
                return Json(new { status = "Authorized",Info= profileInfo });
            }
        }
        protected override void Dispose(bool disposing)

        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
    
}