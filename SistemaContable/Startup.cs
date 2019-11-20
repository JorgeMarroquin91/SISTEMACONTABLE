using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaContable.Startup))]
namespace SistemaContable
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
