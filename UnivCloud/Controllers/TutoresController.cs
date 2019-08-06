using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    public class TutoresController : Controller
    {
        ServicesTutores Services = new ServicesTutores();
        // GET: Tutores
        public ActionResult Consult(int? IndexPage, bool? State)
        {
            var Model = Services.Consult(IndexPage);
            ViewBag.States = State;
            return View(Model);
        }

        [HttpPost]
        public ActionResult Consult(string Code)
        {
            var Model = Services.SearchAdvanced(Code);
            return View(Model);
        }
        public ActionResult Create(bool? State)
        {
            ViewBag.State = State;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                Services.Create(tutor);
                return RedirectToAction("Create", new { State = true });
            }
            return RedirectToAction("Create", new { State = false });
        }
        public ActionResult Delete(string Code)
        {
            var Tutor = Services.ConsultByCode(Code);
            if (Tutor != null)
            {
                Services.Delete(Tutor);
                return RedirectToAction("Consult");
            }
            return View("Error");
        }
        public ActionResult Edit(string Code)
        {
            var Model = Services.ConsultByCode(Code);
            return View(Model);
        }
        [HttpPost]
        public ActionResult Edit(Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                Services.Update(tutor);
                return RedirectToAction("Consult", new { State = true });
            }
            return RedirectToAction("Consult", new { State = false });
        }
    }
}