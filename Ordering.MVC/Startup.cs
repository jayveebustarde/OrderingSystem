using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ordering.MVC.Startup))]
namespace Ordering.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
