using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace UnivCloud
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            CultureInfo oldCI = Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            filters.Add(new HandleErrorAttribute());
        }
    }
}
