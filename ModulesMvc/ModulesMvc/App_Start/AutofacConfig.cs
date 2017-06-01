using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ModulesContracts;
using ModulesMvc.Infrastructure;

namespace ModulesMvc
{
    public static class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(MvcApplication).Assembly;
            builder.RegisterControllers(assembly);
            builder.RegisterFilterProvider();
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterType<SimlpeLogger>().As<ILogger>();
            builder.RegisterModules("plugins");
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); ;
        }
    }
}