using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    public class SchedulesController : Controller
    {

        ServiceSubjects ServiceSubjects = new ServiceSubjects();
        ServicesSchedules Services = new ServicesSchedules();
        // GET: Schedules
        public ActionResult Create(bool? State)
        {
            ViewBag.States = State;
            ServicesEmployee servicesEmployee = new ServicesEmployee();
            var Subjects  = ServiceSubjects.Consult();
            ViewBag.Subjects = new SelectList(Subjects, "Code_Subject", "Name");
            var Professors = servicesEmployee.ConsultProfessor();
            ViewBag.Professors = new SelectList(Professors, "Code_Employee", "Name");
            var Classrooms = ServiceSubjects.ConsultClassrooms();
            ViewBag.Classrooms = new SelectList(Classrooms, "Number_Classroom", "Classroom");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewsModels.Schedules schedules)
        {
            Schedule schedule = new Schedule()
            {
                Code_Schedule = schedules.GetID_Schedules(),
                HourStart = schedules.HourStart,
                HourEnd = schedules.HourEnd,
                Day = schedules.Day,
                Classroom = schedules.Classroom,
                Subject = schedules.Subject
            };
            Schedule_Professor schedule_Professor = new Schedule_Professor()
            {
                Schedule = schedules.GetID_Schedules(),
                Professor = schedules.Professor
            };
            if (ModelState.IsValid)
            {
                Services.Add(schedule);
                Services.AddScheduleProfessor(schedule_Professor);
                return RedirectToAction("Create", new { State = true });
            }
            return RedirectToAction("Create", new { State = false });
        }
        public ActionResult Consult(bool? State, int? IndexPage)
        {
            ViewBag.States = State;
            var Schedules = Services.Consult(IndexPage);
            return View(Schedules);
        }
        
    }
}