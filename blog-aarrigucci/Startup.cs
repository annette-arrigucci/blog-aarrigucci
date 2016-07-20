using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blog_aarrigucci.Startup))]
namespace blog_aarrigucci
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
