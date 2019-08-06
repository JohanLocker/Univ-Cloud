using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;
using PagedList;

namespace UnivCloud_Logica
{
    public class ServicesTutores
    {
        CloudBD BD = new CloudBD();
        public IPagedList<Tutor> Consult(int? i)
        {
            return BD.Tutor.ToList().ToPagedList(i?? 1, 6);
        }

        public Tutor ConsultByCode(string Code)
        {
            return BD.Tutor.Find(Code);
        }
        public IPagedList<Tutor> SearchAdvanced(string Code)
        {
            var Model = BD.Tutor.Where(x => x.ID == Code).ToList().ToPagedList(1,50);
            return Model;
        }

        public void Create(Tutor tutor)
        {
            BD.Tutor.Add(tutor);
            BD.SaveChanges();
        }

        public void Delete(Tutor tutor)
        {
            BD.Tutor.Remove(tutor);
            BD.SaveChanges();
        }

        public void Update(Tutor tutor)
        {
            BD.Entry(tutor).State = EntityState.Modified;
            BD.SaveChanges();
        }
    }
}