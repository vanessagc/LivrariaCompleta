using System.Reflection;
using System.Web.Mvc;
using LivrariaEntity;
using LivrariaEntity.IoC;
using LivrariaMvc.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace LivrariaEntity
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
            BootStrapperApp.RegisterServices(container);
        }
    }
}