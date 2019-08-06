using iTextSharp.text.pdf;
using iTextSharp.text;
using Syncfusion.JavaScript.DataVisualization.Models.Diagram;
using Syncfusion.JavaScript.DataVisualization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UnivCloud_Datos.BaseDatos;
using System.IO;

namespace UnivCloud_Logica
{
    public class ServicesForPDF
    {
        #region Declarations
        int Columns;
        int Rows;
        List<object> Sub;
        Document document;
        DateTime Date = DateTime.Now;
        iTextSharp.text.Font FontStyle;
        PdfPTable Table = new PdfPTable(3);
        PdfPCell Cells;
        MemoryStream Mem = new MemoryStream();

        public ServicesForPDF(int Columns, int Rows, List<object> Sub)
        {
            this.Columns = Columns;
            this.Rows = Rows;
            this.Sub = Sub;
        }
        #endregion

        public byte[] ReportAsPDF()
        {
            // document.AddTitle("Reporte de signaturas" + Date.ToString("dddd, dd MMMM yyyy"));
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);
            Table.WidthPercentage = 100;
            Table.HorizontalAlignment = Element.ALIGN_CENTER;
            FontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, Mem);
            document.Open();

            this.ReportHeader();
            this.ReportBody();

            Table.HeaderRows = 2;
            document.Add(Table);
            document.Close();
            return Mem.ToArray();
        }

        public void ReportHeader()
        {
            FontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            Cells = new PdfPCell(new Phrase("Reporte de asignaturas", FontStyle));
            Cells.Colspan = Columns;
            Cells.HorizontalAlignment = Element.ALIGN_CENTER;
            Cells.Border = 1;
            Cells.BackgroundColor = BaseColor.WHITE;
            Cells.ExtraParagraphSpace = 0;
            Table.AddCell(Cells);
            Table.CompleteRow();
        }
        public void ReportBody()
        {
            FontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            Cells = new PdfPCell(new Phrase("Codigo Asignatura", FontStyle));
            Cells.HorizontalAlignment = Element.ALIGN_CENTER;
            Cells.VerticalAlignment = Element.ALIGN_MIDDLE;
            Cells.BackgroundColor = BaseColor.LIGHT_GRAY;
            Table.AddCell(Cells);

            Cells = new PdfPCell(new Phrase("Asignatura", FontStyle));
            Cells.HorizontalAlignment = Element.ALIGN_CENTER;
            Cells.VerticalAlignment = Element.ALIGN_MIDDLE;
            Cells.BackgroundColor = BaseColor.LIGHT_GRAY;
            Table.AddCell(Cells);

            Cells = new PdfPCell(new Phrase("Horas", FontStyle));
            Cells.HorizontalAlignment = Element.ALIGN_CENTER;
            Cells.VerticalAlignment = Element.ALIGN_MIDDLE;
            Cells.BackgroundColor = BaseColor.LIGHT_GRAY;
            Table.AddCell(Cells);
            Table.CompleteRow();

           /* foreach(var Subs in Sub)
            {
                Cells = new PdfPCell(new Phrase(Subs.Code_Subject, FontStyle));
                Cells.HorizontalAlignment = Element.ALIGN_CENTER;
                Cells.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cells.BackgroundColor = BaseColor.LIGHT_GRAY;
                Table.AddCell(Cells);

                Cells = new PdfPCell(new Phrase(Subs.Name, FontStyle));
                Cells.HorizontalAlignment = Element.ALIGN_CENTER;
                Cells.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cells.BackgroundColor = BaseColor.LIGHT_GRAY;
                Table.AddCell(Cells);

                Cells = new PdfPCell(new Phrase(Convert.ToString(Subs.Credits), FontStyle));
                Cells.HorizontalAlignment = Element.ALIGN_CENTER;
                Cells.VerticalAlignment = Element.ALIGN_MIDDLE;
                Cells.BackgroundColor = BaseColor.LIGHT_GRAY;
                Table.AddCell(Cells);
                Table.CompleteRow();
            }*/


        }
    }
}