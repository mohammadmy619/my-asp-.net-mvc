using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(my_mvc.Startup))]
namespace my_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
