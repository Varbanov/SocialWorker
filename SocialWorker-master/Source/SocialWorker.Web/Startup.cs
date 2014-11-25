using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialWorker.Web.Startup))]
namespace SocialWorker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
