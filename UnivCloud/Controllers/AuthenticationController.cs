using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;
using UnivCloud_Logica.ViewModels;

namespace UnivCloud.Controllers
{
    public class AuthenticationController : Controller
    {
        //Initialization Objects Models 

        [HttpGet]
        public ActionResult LogIn()
        {
            if (Session["User"]!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User User)
        {
            ServicesUser Services = new ServicesUser(User.UserLogin);
            if (ModelState.IsValid)
            {
                var Valid = Services.ValidationUser(User.UserLogin, User.PasswordLogin);
                if (Valid)
                {
                    //Si el usuario es Válido...
                    FormsAuthentication.SetAuthCookie(User.UserLogin, false);
                    PanelUsers Employee = Services.ControlPanel();
                    Session["User"] = User.UserLogin;
                    Session["Employee"] = Employee;
                    return RedirectToAction("Index", "Home");
                }
                // Si el usuario no existe, o los datos no son correctos.
                TempData["State"] = "Usuario o contraseña incorrecto";
                return View();
            }
            // Si no ingreso los datos.
            ModelState.AddModelError("Error", "Usuario o contraseña Invalidos");
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("LogIn", "Authentication");
        }
    }
}