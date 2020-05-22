using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApp.Models
{
    public class ProfileInfo
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AlternateEmails { get; set; }
        public string ContactNo { get; set; }
        public string AlternateContactNo { get; set; }
        public byte[] ImageBinaryData { get; set; }
        public string UserName { get; set; }
       // public virtual RegistrationInfo registrationInfo { get; set; }
    }
}