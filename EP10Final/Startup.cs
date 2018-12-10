using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EP10Final.Startup))]
namespace EP10Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
