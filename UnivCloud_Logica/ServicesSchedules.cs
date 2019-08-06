using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;

namespace UnivCloud_Logica
{
    public class ServicesSchedules
    {
        CloudBD BD = new CloudBD();

        public void Add(Schedule schedule)
        {
            BD.Schedule.Add(schedule);
            BD.SaveChanges();
        }
        public void AddScheduleProfessor(Schedule_Professor schedule_Professor)
        {
            BD.Schedule_Professor.Add(schedule_Professor);
            BD.SaveChanges();
        }

        public IPagedList<Schedules_Assigneds> Consult(int? indexPage)
        {
            var Consult = BD.Schedules_Assigneds.ToList().ToPagedList(indexPage ?? 1, 6);
            return Consult;
        }
    }
}