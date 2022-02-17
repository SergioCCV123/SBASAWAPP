using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBASAWAPP.Startup))]
namespace SBASAWAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
