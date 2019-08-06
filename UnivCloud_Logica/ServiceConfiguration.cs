using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;

namespace UnivCloud_Logica
{
    public class ServiceConfiguration
    {
        CloudBD BD = new CloudBD();
        public Configuration Consult(string User)
        {
            return BD.Configuration.Where(x => x.Username == User).FirstOrDefault();
        }

        public void Update(Configuration Data)
        {
            var Emp = BD.Users.Where(x => x.Username == Data.Username).FirstOrDefault().Employee;
            BD.UpdateConfiguration(Emp, Data.Address, Data.Mail, Data.Telephone, Data.Image);
            BD.SaveChanges();
        }
    }
}