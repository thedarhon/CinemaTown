using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaTown.Startup))]
namespace CinemaTown
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
