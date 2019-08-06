using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    public class UsersController : Controller
    {
        ServicesUser Services = new ServicesUser();
        // GET: Users
        public ActionResult Create()
        {
            var Priv = Services.ConsultPrivileges();
            ViewBag.Privs = new SelectList(Priv, "ID_Privileges", "Description");
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateUser User)
        {
            if (ModelState.IsValid)
            {
                Users Us = new Users()
                {
                    Username = User.User,
                    Password = User.Password,
                    Employee = User.CodeEmployee,
                    Privilege = User.Privileges,
                    Status = false
                };
                bool Valid = Services.CreateUser(Us);
                if (Valid)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Create");
        }
        public ActionResult Consult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Consult(string Username)
        {
            var User = Services.ConsultByUser(Username);
            return View(User);
        }
    }
}