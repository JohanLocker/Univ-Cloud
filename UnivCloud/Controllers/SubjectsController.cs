using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica;

namespace UnivCloud.Controllers
{
    [Authorize]
    [HandleError(ExceptionType = typeof(DbUpdateException), View = "Error")]
    public class SubjectsController : Controller
    {
        ServiceSubjects Service = new ServiceSubjects();
        ServiceStudents ServiceStudents = new ServiceStudents();
        // GET: Subjects
        public ActionResult Create(bool? State)
        {
            ViewBag.State = State;
            var Grades = ServiceStudents.ConsultGrades();
            ViewBag.Grades = new SelectList(Grades, "Code_Grade", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Subject Subject)
        {
           if (ModelState.IsValid)
           {
                if (Service.Add(Subject))
                {
                    return RedirectToAction("Create", new { State = true });
                }
           }
           return RedirectToAction("Create", new { State = false });
        }
        public ActionResult Consult(bool? State, int? IndexPage, string Search )
        {
            ViewBag.States = State;
            var Model = Service.Consult(IndexPage);
            var Grades = ServiceStudents.ConsultGrades();
            ViewBag.Grades = new SelectList(Grades, "Code_Grade", "Name");
            return View(Model);

        }
        [HttpPost]
        public ActionResult Consult(string Code, int? Grade, bool? State)
        {
            ViewBag.States = State;
            var Grades = ServiceStudents.ConsultGrades();
            ViewBag.Grades = new SelectList(Grades, "Code_Grade", "Name");
            var Model = Service.SearchAdvanced(Code, Grade);
            return View(Model);
        }
        [HttpPost]
        public ActionResult Delete(string Code)
        {
            var Subject = Service.ConsultByCode(Code);
            if (Subject != null)
            {
                Service.Delete(Subject);
                return RedirectToAction("Consult", new { State = true});

            }
            return View("Error");
        }
        public ActionResult Edit(string Code)
        {
            var Model = Service.ConsultByCode(Code);
            var Grades = ServiceStudents.ConsultGrades();
            ViewBag.Grades = new SelectList(Grades, "Code_Grade", "Name");

            return View(Model);
        }
        [HttpPost]
        public ActionResult Edit(Subject Subject)
        {
            if (ModelState.IsValid)
            {
                Service.Update(Subject);
                ViewBag.Grades = ServiceStudents.ConsultGrades();

                return RedirectToAction("Consult", new { State = true });
            }
            return View("Error");
        }

        public ActionResult Reports(string ReportType)
        {
            DateTime time = DateTime.Now;
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Reports/Subjects.rdlc");
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
            Response.AddHeader("content-disposition", "attachment;filename= Subject."+ filenameExtension);
            return File(renderedByte, filenameExtension);
        }

    }
}