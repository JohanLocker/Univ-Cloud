using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;

namespace UnivCloud_Logica
{
    public class ServiceSubjects
    {
        CloudBD BD = new CloudBD();
        public bool Add(Subject subject)
        {
            var Exist = BD.Subject.Where(x => x.Code_Subject == subject.Code_Subject).FirstOrDefault();
            if (Exist == null)
            {
                BD.Subject.Add(subject);
                BD.SaveChanges();
                return true;
            }
            return false;
        }
        public List<ClassRoomsView> ConsultClassrooms()
        {
            return BD.ClassRoomsView.ToList();
        }
        public Subject ConsultByCode(string Code)
        {
            return BD.Subject.Find(Code);
        }


        public List<Subject> Consult()
        {
            return BD.Subject.ToList();
        }
        public IPagedList<Subject> Consult(int? i)
        {
            return BD.Subject.ToList().ToPagedList(i ?? 1,6);
        }

        public void Delete(Subject Subject)
        {
            BD.Subject.Remove(Subject);
            BD.SaveChanges();
        }

        public void Update(Subject Subject)
        {
            BD.Entry(Subject).State = EntityState.Modified;
            BD.SaveChanges();
        }

        public IPagedList<Subject> SearchAdvanced(string Code, int? Grade)
        {
             var Model = BD.Subject.Where(x => x.Code_Subject.Contains(Code)).ToList().ToPagedList(1,100);
            if (Grade != null)
            {
                Model = Model.Where(x => x.Grade == Grade).ToList().ToPagedList(1, 20);
            }
            return Model;

        }
    }
}