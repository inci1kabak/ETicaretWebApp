using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETicaretWebApp.Startup))]
namespace ETicaretWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
