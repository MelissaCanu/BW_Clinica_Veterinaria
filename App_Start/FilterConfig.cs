using System.Web;
using System.Web.Mvc;

namespace BW_Clinica_Veterinaria
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
