using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RegistrationApp.Models
{
    public class RegistrtionInfoMap:EntityTypeConfiguration<RegistrationInfo>
    {
        public RegistrtionInfoMap()
        {
            this.HasKey(t => t.Id);
              
            this.ToTable("RegistrationInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}