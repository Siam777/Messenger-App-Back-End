using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApp.Models
{
    public class RegistrationInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public virtual ProfileInfo profileInfo { get; set; }
    }
}