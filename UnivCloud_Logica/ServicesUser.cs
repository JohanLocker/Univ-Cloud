using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;
using UnivCloud_Logica.ViewModels;

namespace UnivCloud_Logica
{
    public class ServicesUser
    {
        public string Username { get; set; }
        public string Passsword { get; set; }
        public ServicesUser(string _Username)
        {
            Username = _Username;
        }
        public ServicesUser()
        {
        }

        CloudBD BD = new CloudBD();

        public List<Privileges> ConsultPrivileges()
        {
            var Privileges = BD.Privileges.ToList();
            return Privileges;
        }
        public bool ValidationUser(string User, string Password)
        {
           var Query = BD.Users.Select(x => x).Where(x => x.Username == User && x.Password == Password).Count();
            if (Query >= 1)
            {
                return true;
            }
            return false;
        }

        public PanelUsers ControlPanel()
        {
            return BD.PanelUsers.Where(x => x.Username == Username).FirstOrDefault();
        }

        public bool CreateUser(Users user)
        {
            try
            {
                BD.Users.Add(user);
                BD.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ConsultUsers ConsultByUser(string Username)
        {
            return BD.ConsultUsers.Where(x => x.Username == Username).FirstOrDefault();
        }

        public bool CodigoEmpleadoExistente(string Code)
        {
            var Existe = BD.Employee.Select(x => x).Where(x => x.Code_Employee == Code).Count();
            if (Existe>=1)
            {
                return true;
            }
            return false;
        }
  /*      public string RegistrarUsuario(string Usuario, string Contrasena, string Empleado)
        {
            if (CodigoEmpleadoExistente(Empleado))
            {
                Usuarios usuario = new Usuarios()
                {
                    Usuario = Usuario,
                    Contrasena = Contrasena,
                    Empleado = Empleado,
                    Privilegios = 1
                };
                BD.Usuarios.Add(usuario);
                BD.SaveChanges();
                return "Usuario creado exitosamente!";
            }
            return "Error: El empleado no existe, o no esta registrado";
        }*/
        public Employee FindEmployee()
        {
          var Emp = BD.Users.Where(x => x.Username == Username).FirstOrDefault().Employee;
          return BD.Employee.Select(X => X).Where(x => x.Code_Employee == Emp).FirstOrDefault();
        }
    }
}