using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyBudgetWeb.Startup))]
namespace FamilyBudgetWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
