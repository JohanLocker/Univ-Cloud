using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using UnivCloud_Datos.BaseDatos;

namespace UnivCloud_Logica
{
    public class ServicesMail
    {
        public void TemplateMail(string Mail, Employee Employee)
        {
            string Body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/Views/Mail/") + "Mail" + ".cshtml");
            Body = Body.ToString();
            CreateMail("Su cuenta ha sido creada, Verifique, Empleado: " + Employee.Name, Body, Mail);
        }
        public static void CreateMail(string Subject, string Body, string Addresses)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append(Body);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("developerunivs@gmail.com");
            mail.To.Add(Addresses);
            mail.Subject = Subject;
            mail.Body = SB.ToString();
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            SendMail(mail);
        }

        public static void SendMail(MailMessage Mail)
        {
            SmtpClient Client = new SmtpClient();
            Client.Host = "smtp.gmail.com";
            Client.Port = 587;
            Client.EnableSsl = true;
            Client.UseDefaultCredentials = false;
            Client.DeliveryMethod = SmtpDeliveryMethod.Network;
            Client.Credentials = new System.Net.NetworkCredential("developerunivs@gmail.com", "Radarada1218");
            try
            {
                Client.Send(Mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}