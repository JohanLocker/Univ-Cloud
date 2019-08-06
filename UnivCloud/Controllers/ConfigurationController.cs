using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    public class ConfigurationController : Controller
    {
        ServiceConfiguration Services = new ServiceConfiguration();
        SaveImages Image = new SaveImages();

        // GET: Configuration
        public ActionResult Configuration(string User)
        {
            var model =Services.Consult(User);
            return View(model);
        }
       [HttpPost]
        public ActionResult Configuration(Configuration Data)
        {
            if(ModelState.IsValid)
            {
                Data.Image = Image.Save(Data.Image, Data.Username);
                Services.Update(Data);
                return RedirectToAction("LogIn", "Authentication");
            }
            return RedirectToAction("LogIn", "Authentication");
        }

    }
}