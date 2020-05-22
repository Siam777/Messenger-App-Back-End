using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistrationApp.Models
{
    public class AppContext:DbContext
    {
        public AppContext():base("Name=AppContext")
        {

        }
        public DbSet<RegistrationInfo> RegistrationInfo { get; set; }
        public DbSet<ProfileInfo> ProfileInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RegistrtionInfoMap());
            modelBuilder.Configurations.Add(new ProfileInfoMap());
        }
    }
}