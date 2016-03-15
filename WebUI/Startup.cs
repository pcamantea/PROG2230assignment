using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleMVCSite.Startup))]
namespace SampleMVCSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
