using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UtilityPay.Startup))]
namespace UtilityPay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
