using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RegistrationApp.Models
{
    public class ProfileInfoMap:EntityTypeConfiguration<ProfileInfo>
    {
        public ProfileInfoMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("ProfileInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegistrationId).HasColumnName("RegistrationId");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.ImageBinaryData).HasColumnName("ImageBinaryData");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.ContactNo).HasColumnName("ContactNo");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.AlternateContactNo).HasColumnName("AlternateContactNo");
            this.Property(t => t.AlternateEmails).HasColumnName("AlternateEmails");
            this.Property(t => t.UserName).HasColumnName("UserName");
           // this.HasRequired(t => t.registrationInfo)
                // .WithRequiredPrincipal(t => t.profileInfo);
                 //.HasForeignKey(d => d.RegistrationId);
        }
    }
}