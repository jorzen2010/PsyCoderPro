using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PsyCoderWechat.Startup))]
namespace PsyCoderWechat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
