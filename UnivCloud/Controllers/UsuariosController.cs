using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    public class UsuariosController : Controller
    {

        ServicesUser Servicio = new ServicesUser();
        ServicesMail Correo = new ServicesMail();
        // GET: Usuarios
        public ActionResult Reporte()
        {
            return View();
        }
        public ActionResult Crear(RegistroUsuario Usuario)
        {
            if (ModelState.IsValid)
            {
               // var State= Servicio.Regist(Usuario.UsuarioR, Usuario.ContrasenaR, Usuario.Empleado);
              //  var Empleado = Servicio.EmpleadoPorUsuario(Usuario.UsuarioR);
               // TempData.Add("Estado", Stat);
                return RedirectToAction("LogIn", "Authentication");
            }
            return View();

        }
        public ActionResult ActivarUsuario(string Usuario)
        {
            return View("ActivarUsuario", Usuario);
        }
    }
}