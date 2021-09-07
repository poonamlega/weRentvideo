using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(weRentvideo.Startup))]
namespace weRentvideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
