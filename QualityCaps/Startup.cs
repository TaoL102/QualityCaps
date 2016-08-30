using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QualityCaps.Startup))]
namespace QualityCaps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
