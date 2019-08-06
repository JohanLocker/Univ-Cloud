using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;

namespace UnivCloud_Logica
{
    public class ServicesEmployee
    {
        CloudBD BD = new CloudBD();
        public List<Position> ConsultPositions()
        {
            var positions = BD.Position.ToList();
            return positions;
        }
        public List<EmployeProfessor> ConsultProfessor()
        {
            return BD.EmployeProfessor.Select(x=>x).ToList();
        }
        public bool Add(Employee Employee)
        {
            var ExistEmp = ConsultByCode(Employee.Code_Employee);
            if (ExistEmp == null)
            {
                BD.Employee.Add(Employee);
                BD.SaveChanges();
                return true;
            }
            return false;
        }
        public string LastRow()
        {
            var Ultimo = BD.Employee.Select(x => x).OrderByDescending(x => x.Code_Employee).FirstOrDefault().Code_Employee;
            Ultimo = Ultimo +1;
            return Ultimo;
        }

        public void EmployeeActive(int Code)
        {
            var model = BD.Employee.Find(Code);
            if (model != null)
            {
                if (model.Status)
                {
                    model.Status = false;
                }
                else
                {
                    model.Status = true;
                }
                Update(model);
            }
        }

        public IPagedList<Employee> Consult(int? i)
        {
            var Employee = BD.Employee.ToList().ToPagedList(i??1, 6);
            return Employee;
        }
        public IPagedList<Employee> Consult()
        {
            var Employee = BD.Employee.ToList().ToPagedList(1, 6);
            return Employee;
        }

        public IPagedList<Employee> SearchAdvanced(string Code, string Positions, int? i)
        {
            
            var Find = BD.Employee.Where(x => x.Position.Contains(Positions)).ToList().ToPagedList(i?? 1,6);
            if (Code != null)
            {
                Find = Find.Where(x => x.Code_Employee.Contains(Code)).ToList().ToPagedList(i ?? 1, 6);
            }
            return Find;
        }

        public object ConsultByCode(string Code)
        {
            return BD.Employee.Find(Code);
        }

        public void Delete(object Employee)
        {
            BD.Employee.Remove((Employee)Employee);
            BD.SaveChanges();
        }

        public void Update(Employee Employee)
        {
            BD.Entry(Employee).State = EntityState.Modified;
            BD.SaveChanges();
        }
    }
}