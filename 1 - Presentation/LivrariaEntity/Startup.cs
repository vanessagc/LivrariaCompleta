using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LivrariaEntity.Startup))]
namespace LivrariaEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
