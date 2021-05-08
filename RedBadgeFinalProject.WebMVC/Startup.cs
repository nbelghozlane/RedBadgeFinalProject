using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using RedBadgeFinalProject.Services;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(RedBadgeFinalProject.WebMVC.Startup))]
namespace RedBadgeFinalProject.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<EventService>().As<IEventService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            ConfigureAuth(app);
        }
    }
}
