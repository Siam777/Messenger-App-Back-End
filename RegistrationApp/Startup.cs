using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(RegistrationApp.Startup))]
namespace RegistrationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // app.UseCors(CorsOptions.AllowAll);
        }
        
    }
}
