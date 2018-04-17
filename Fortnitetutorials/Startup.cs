using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fortnitetutorials.Startup))]
namespace Fortnitetutorials
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
