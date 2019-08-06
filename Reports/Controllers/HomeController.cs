using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UnivCloud_Datos.BaseDatos;

namespace Reports.Controllers
{
    public class HomeController : Controller
    {
        ReportViewer RV = new ReportViewer();
        public ActionResult Index(string ID)
        {
            LocalReport LR = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Views/Shared"), "Report.rdlc");
            if (System.IO.File.Exists(path))
            {
                LR.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Subject> cm = new List<Subject>();
            using (CloudBD dc = new CloudBD())
            {
                cm = dc.Subject.ToList();
            }
            ReportDataSource rd = new ReportDataSource("ReportViewer", cm);
            LR.DataSources.Add(rd);
            string reportType = ID;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            " <OutputFormat>" + ID + "</OutputFormat>" +
            " <PageWidth>8.5in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight>1in</MarginRight>" +
            " <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;

            byte[] renderedBytes = LR.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);


            return File(renderedBytes, mimeType);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}