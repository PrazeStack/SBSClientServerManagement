using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBSClientServerManager.Startup))]
namespace SBSClientServerManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
