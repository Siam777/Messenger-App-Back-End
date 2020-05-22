using RegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WMS.Models.VM;
using static RegistrationApp.MvcApplication;

namespace RegistrationApp.Api
{
    public class LoginController : ApiController
    {

        AppContext db = new AppContext();
        // GET: Login
        [HttpPost]
        [Route("api/Login/Registrationsave")]

        
        public Status RegistrationSave(RegistrationInfo registration)
        {
            Status st = new Status();

            if (registration != null && registration.Email != null && registration.Password != null && registration.Name != null)
            {
               
                try
                {
                    db.RegistrationInfo.Add(registration);
                    db.SaveChanges();

                    ProfileInfo info = new ProfileInfo();
                    var registrationId = db.RegistrationInfo.Max(s => s.Id);
                    info.RegistrationId = registrationId;
                    info.Email = registration.Email;
                    info.UserName = registration.Name;
                    db.ProfileInfo.Add(info);
                    db.SaveChanges();
                    st.message = "Successfully Registered";
                }
                catch(Exception ex) {
                    st.message = ex.Message;
                }
                   
               
            }
            return st;
        }

        [HttpGet]
        [Route("api/Login/Authorization")]
        public object CheckLogIn(string name, string password)
        {
            var loginInfo = db.RegistrationInfo.Where(x => x.Name == name && x.Password == password).FirstOrDefault();
            if (loginInfo == null)
            {
               
                return Json(new { status = "Unauthorized" });
            }
            else
            {
                 Sessions.UserId = loginInfo.Id;
                var profileInfo = db.ProfileInfo.Where(x => x.RegistrationId == loginInfo.Id).SingleOrDefault();
                var Token = TokenManager.GenerateToken((profileInfo.RegistrationId).ToString());
                return Json(new { status = "Authorized", Info = Token });
            }
        }

        [HttpGet]
        [Route("api/Login/GetProfileInfo")]
        public object ProfileInfo()
        {                       
                var profileInfo = db.ProfileInfo.Where(x => x.RegistrationId == Sessions.UserId).SingleOrDefault();
                return Json(new {Info = profileInfo });
           
        }

        [HttpGet]
        [Route("api/Login/CheckIdentity")]
        public object CheckUserNameandPassword(string name,string value)
        {
            bool Existance = false;
            if (name == "UserName")
            {
                var UserNameCheck = db.RegistrationInfo.Select(x => x.Name == value).FirstOrDefault();
                if(UserNameCheck == null)
                {
                    Existance = true;
                }
            }
            if (name == "Email")
            {
                var EmailCheck = db.RegistrationInfo.Select(x => x.Email == value).FirstOrDefault();
                if (EmailCheck == null)
                {
                    Existance = true;
                }
            }
            // var profileInfo = db.ProfileInfo.Where(x => x.RegistrationId == Sessions.UserId).SingleOrDefault();
            return Json(new { status = Existance });

        }
        [HttpGet]
        [Route("api/Login/CheckIdentity")]
        public Status ResetPassword(string newPassword,string oldPassword)
        {
            Status st = new Status();
            var passCheck = db.RegistrationInfo.Where(x => x.Id == Sessions.UserId && x.Password == oldPassword).SingleOrDefault();
            if (passCheck == null)
            {
                st.message = "Current password is invalid";
                return st;
            }
            RegistrationInfo info = db.RegistrationInfo.Where(x => x.Id == Sessions.UserId).SingleOrDefault();
            info.Password = newPassword;
            db.Entry(info).State = EntityState.Modified;
            db.SaveChanges();
            st.message = "Successfully Updated";
            return st;

        }
        protected override void Dispose(bool disposing)

        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}
