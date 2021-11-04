using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementStudentSystem.Startup))]
namespace ManagementStudentSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
