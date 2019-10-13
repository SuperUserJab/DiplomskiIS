using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiplomskiISpoljoprivreda.Startup))]
namespace DiplomskiISpoljoprivreda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
