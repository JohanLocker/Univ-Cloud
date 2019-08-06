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
 //   [Authorize(Roles ="Administrador")]
    public class EmployeesController : Controller
    {
        ServicesMail Mail = new ServicesMail();
        SaveImages images = new SaveImages();
        ServicesEmployee Services = new ServicesEmployee();

        public ActionResult Create(bool? State)
        {
            var Positions = Services.ConsultPositions();
            ViewBag.Positions = new SelectList(Positions, "ID_Position","Position1");
            ViewBag.States = State;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Image = images.Save(employee.Image, employee.Code_Employee, true);
                if (Services.Add(employee))
                {
                    Mail.TemplateMail(employee.Mail, employee);
                    return RedirectToAction("Create", new { State = true });
                }
            }
            return RedirectToAction("Create", new { State = false });
        }
        public ActionResult ActiveUser(int Code)
        {
            return RedirectToAction("Consult");
        }
        public ActionResult Consult(int? IndexPage)
        {
            var Model = Services.Consult(IndexPage);
            var Positions = Services.ConsultPositions();
            ViewBag.Position = new SelectList(Positions, "ID_Position", "Position1");
            return View(Model);
        }
        [HttpPost]
        public ActionResult Consult(string Code, string Position, int? IndexPage)
        {
            var Positions = Services.ConsultPositions();
            ViewBag.Position = new SelectList(Positions, "ID_Position", "Position1");
            var Model = Services.SearchAdvanced(Code, Position, IndexPage);
            return View(Model);

        }
        [HttpPost]
        public ActionResult Delete(string Code)
        {
            var employee = Services.ConsultByCode(Code);
            if(employee != null)
            {
                Services.Delete(employee);
                return RedirectToAction("Consult");
            }
            return View("Error");
        }
        public ActionResult Edit(string Code)
        {
            var Model = Services.ConsultByCode(Code);
            var Positions = Services.ConsultPositions();
            ViewBag.Positions = new SelectList(Positions, "ID_Position", "Position1");
            return View(Model);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Services.Update(employee);
                return RedirectToAction("Consult");
            }
            return View("Error");
        }
        public ActionResult Reports(string ReportType)
        {
            DateTime time = DateTime.Now;
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Reports/EmployeesReport.rdlc");
            ReportDataSource RP = new ReportDataSource();
            RP.Name = "Cloud";
            RP.Value = Services.Consult();
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
            Response.AddHeader("content-disposition", "attachment;filename= EmpleadosReporte." + filenameExtension);
            return File(renderedByte, filenameExtension);
        }
    }
}