using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reporter_MVC.Startup))]
namespace Reporter_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
