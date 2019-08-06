using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnivCloud_Datos.BaseDatos;

namespace UnivCloud_Logica
{
    public class ServiceStudents
    {
        CloudBD BD = new CloudBD();
        public IPagedList<Students> Consult(int? i)
        {
            return BD.Students.ToList().ToPagedList(i ?? 1,6);
        }
        public List<Students> Consult()
        {
            return BD.Students.ToList().ToList();
        }

        public string AssignedClassroom(string grade)
        {
            int Grad = Convert.ToInt32(grade);
            var Grades = BD.Classroom.Where(x => x.Grade == Grad).ToArray();
            for(int i =0; i <= Grades.Length; i++)
            {
                string NumberClassroom = Grades[i].Number_Classroom;
                var StudentsByClassrooms = BD.Students.Where(x => x.Classroom == NumberClassroom);
                if (StudentsByClassrooms.Count() <= 30)
                {
                    return Grades[i].Number_Classroom;
                }
            }
            return "Null";
        }
        public List<ClassRoomsView> ClassRooms()
        {
            var Classroom =  BD.ClassRoomsView.OrderBy(x => x.Classroom).ToList();
            return Classroom;
        }
        public object SearchAdvanced(string Enrollment, int? Grade)
        {
            var Model = BD.Students.Where(x => x.Enrollment.Contains(Enrollment)).ToList().ToPagedList(1,50);
            if(Grade != null)
            {
                Model = Model.Where(x => x.Classroom1.Grade == Grade).ToList().ToPagedList(1,20);
            }
            return Model;
        }

        public dynamic ConsultGrades()
        {
            return BD.Grades.ToList();
        }

        public void Create(Students students)
        {
            BD.Students.Add(students);
            BD.SaveChanges();
        }

        public Students ConsultByCode(string Code)
        {
            var Student = BD.Students.Find(Code);
            return Student;
        }
        public string LastEnrollment()
        {
            var Last = BD.Students.OrderByDescending(x => x.Enrollment).FirstOrDefault();
            return Last.Enrollment;
        }
        public void Delete(Students students)
        {
            BD.Students.Remove(students);
            BD.SaveChanges();
        }

        public void update(Students student)
        {
            BD.Entry(student).State = EntityState.Modified;
            BD.SaveChanges();
        }
    }
}