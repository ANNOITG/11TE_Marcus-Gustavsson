using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OSOPMCC5NEW.Startup))]
namespace OSOPMCC5NEW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
