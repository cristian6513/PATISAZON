using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PATISAZON.Startup))]
namespace PATISAZON
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
