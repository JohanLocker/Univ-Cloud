using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnivCloud_Logica
{
    public class SaveImages
    {
        UnivCloud_Datos.BaseDatos.CloudBD BD = new UnivCloud_Datos.BaseDatos.CloudBD();
        public string Complement { get; set; }
        public SaveImages()
        {
            Complement = "/Resources/Images/";
        }
        public string Save(string Image, string user)
        {
            if(Image==null)
            {
              var emp = BD.Users.Where(x => x.Username == user).FirstOrDefault().Employee;
              Image = BD.Employee.Where(x => x.Code_Employee == emp).FirstOrDefault().Image;
            }
            if (Image.Contains("/"))
            {
                return Image;
            }
            return Complement + Image;
        }
        public string Save(string Image, string Emp, bool Value)
        {
            if (Image == null)
            {
                var Query = BD.Employee.Where(x => x.Code_Employee == Emp).FirstOrDefault();
                if (Query == null)
                {
                    return Image = Complement + "user.png";
                }
                else
                {
                    if (Query.Image.Contains("/"))
                    {
                        return Image;
                    }
                }
            }
            return Complement + Image;
        }
    }
}