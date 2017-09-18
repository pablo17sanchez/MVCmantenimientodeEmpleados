using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpleadosEDM.Startup))]
namespace EmpleadosEDM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
