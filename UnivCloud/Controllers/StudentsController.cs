using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        ServiceStudents Service = new ServiceStudents();
        ServiceStudents ServiceStudents = new ServiceStudents();
        // GET: Estudiantes
        public ActionResult Consult(int? IndexPage, bool? state)
        {
            ViewBag.States = state;
            var Grades = ServiceStudents.ConsultGrades();
            ViewBag.Grades = new SelectList(Grades, "Code_Grade", "Name");
            var Model = Service.Consult(IndexPage);
            return View(Model);
        }
        [HttpPost]
        public ActionResult Consult(string Enrollment, int? Grade)
        {
            var Grades = ServiceStudents.ConsultGrades();
            ViewBag.Grades = new SelectList(Grades, "Code_Grade", "Name");
            var Model = Service.SearchAdvanced(Enrollment, Grade);
            return View(Model);
        }
        public ActionResult Create(bool? State)
        {
            ViewBag.States = State;
            var Grade = Service.ConsultGrades();
            ViewBag.Grades = new SelectList(Grade, "Code_Grade", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                students.Classroom = Service.AssignedClassroom(students.Classroom);
                Service.Create(students);
                return RedirectToAction("Create", new { State = true });
            }
            return RedirectToAction("Create", new { State = false });
        }
        public ActionResult Delete(string Code)
        {
            var Students = Service.ConsultByCode(Code);
            if (Students != null)
            {
                Service.Delete(Students);
                return RedirectToAction("Consult");
            }
            return View("Error");
        }
        public ActionResult Edit(string Code)
        {
            var Student = Service.ConsultByCode(Code);
            var ClassRooms = Service.ClassRooms();
            ViewBag.Classrooms = new SelectList(ClassRooms, "Number_Classroom", "Classroom");
            return View(Student);
        }

        [HttpPost]
        public ActionResult Edit(Students student)
        {
            if (ModelState.IsValid)
            {
                Service.update(student);
                return RedirectToAction("Consult", new { state=true});
            }
            return View();
        }
        public ActionResult Reports(string ReportType)
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Reports/StudentsReport.rdlc");
            ReportDataSource RP = new ReportDataSource();
            RP.Name = "Cloud";
            RP.Value = Service.Consult();
            lr.DataSources.Add(RP);
            string reportType = ReportType;
            string MimeType, enconding, filenameExtension;
            switch (reportType)
            {
                case "Excel":
                    filenameExtension = "xlsx";
                    break;
                case "Word":
                    filenameExtension = "docx";
                    break;
                case "PDF":
                    filenameExtension = "pdf";
                    break;
                case "JPG":
                    filenameExtension = "jpg";
                    break;
                default:
                    filenameExtension = "xslx";
                    break;
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = lr.Render(reportType, "", out MimeType, out enconding, out filenameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename= ReporteEstudiantes." + filenameExtension);
            return File(renderedByte, filenameExtension);
        }
    }
}