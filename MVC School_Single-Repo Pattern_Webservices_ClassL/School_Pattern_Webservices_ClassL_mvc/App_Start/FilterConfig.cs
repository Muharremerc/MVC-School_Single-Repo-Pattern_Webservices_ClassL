using System.Web;
using System.Web.Mvc;

namespace School_Pattern_Webservices_ClassL_mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
