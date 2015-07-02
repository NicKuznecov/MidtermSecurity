using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(midterm_nick.Startup))]
namespace midterm_nick
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
