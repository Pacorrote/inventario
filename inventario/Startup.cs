using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inventario.Startup))]
namespace inventario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
