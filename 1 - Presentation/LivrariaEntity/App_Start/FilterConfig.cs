using System.Web.Mvc;
using LivrariaMvc.Infra.CrossCutting;
using SimpleInjector;

namespace LivrariaEntity
{
    public class FilterConfig
    {

        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //}

        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalFilterTool>());
        }

    }
}
