﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnivCloud_Datos.BaseDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CloudBD : DbContext
    {
        public CloudBD()
            : base("name=CloudBD")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Privileges> Privileges { get; set; }
        public virtual DbSet<Professor_Subject> Professor_Subject { get; set; }
        public virtual DbSet<Record_Maintenance> Record_Maintenance { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Schedule_Professor> Schedule_Professor { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Tutor> Tutor { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ClassRoomsView> ClassRoomsView { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<ConsultUsers> ConsultUsers { get; set; }
        public virtual DbSet<EmployeProfessor> EmployeProfessor { get; set; }
        public virtual DbSet<PanelUsers> PanelUsers { get; set; }
        public virtual DbSet<Professor_Subjects_Assigned> Professor_Subjects_Assigned { get; set; }
        public virtual DbSet<Schedules_Assigneds> Schedules_Assigneds { get; set; }
        public virtual DbSet<StudentsClassrooms> StudentsClassrooms { get; set; }
    
        public virtual int UpdateConfiguration(string code, string address, string mail, string tel, string image)
        {
            var codeParameter = code != null ?
                new ObjectParameter("Code", code) :
                new ObjectParameter("Code", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var mailParameter = mail != null ?
                new ObjectParameter("Mail", mail) :
                new ObjectParameter("Mail", typeof(string));
    
            var telParameter = tel != null ?
                new ObjectParameter("Tel", tel) :
                new ObjectParameter("Tel", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateConfiguration", codeParameter, addressParameter, mailParameter, telParameter, imageParameter);
        }
    }
}
