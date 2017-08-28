using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PsyCoderAdmin.Startup))]
namespace PsyCoderAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
