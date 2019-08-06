using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnivCloud.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("LogIn", "Authentication");
            }
            return View();
        }
    }
}