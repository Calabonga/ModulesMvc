using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;

namespace ModulesMvc.Infrastructure
{
    public static class AutofacExtension
    {
        public static void RegisterModules(this ContainerBuilder builder, string pluginsPath)
        {
            var mapPath = HttpContext.Current.Server.MapPath(string.Concat("~/", pluginsPath));
            var dir = new DirectoryInfo(mapPath);
            var dlls = dir.GetFiles("*.dll");
            if (dlls != null && dlls.Any())
            {
                foreach (var item in dlls)
                {
                    if (item.Name.Contains("Module"))
                    {
                        var asmb = Assembly.LoadFile(Path.Combine(mapPath, item.Name));
                        builder.RegisterAssemblyTypes(asmb).AsImplementedInterfaces();
                    }
                }
            }
        }
    }
}