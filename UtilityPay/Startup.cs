using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;
using System;
using System.ComponentModel;
using System.Web.Hosting;
using UtilityPay.Interfaces;
using UtilityPay.Models;

[assembly: OwinStartupAttribute(typeof(UtilityPay.Startup))]
namespace UtilityPay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies, then...
            var container = builder.Build();

            // Register the Autofac middleware FIRST. This also adds
            // Autofac-injected middleware registered with the container.
            app.UseAutofacMiddleware(container);

            // ...then register your other middleware not registered
            // with Autofac.
            ConfigureAuth(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConsumer, Consumer>();
            services.AddTransient<IUtilityServiceAccount, UtilityServiceAccount>();
        }
    }
}
