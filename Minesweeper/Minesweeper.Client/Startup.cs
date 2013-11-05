using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Minesweeper.Client.Startup))]
namespace Minesweeper.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
