//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            this.Notes = new HashSet<Notes>();
        }
    
        public string Enrollment { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public System.DateTime Birth_Date { get; set; }
        public string Gender { get; set; }
        public string Classroom { get; set; }
        public string Nacionality { get; set; }
        public string Tutor { get; set; }
        public bool Status { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    
        public virtual Classroom Classroom1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notes> Notes { get; set; }
        public virtual Tutor Tutor1 { get; set; }
    }
}