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
    
    public partial class Notes
    {
        public string ID_Notes { get; set; }
        public string Student { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Partial_1 { get; set; }
        public Nullable<int> Partial_2 { get; set; }
        public Nullable<int> Partial_3 { get; set; }
        public Nullable<int> Partial_4 { get; set; }
        public Nullable<int> Exam_General { get; set; }
        public Nullable<int> Exam_Completive { get; set; }
        public Nullable<int> Exam_Extraordinary { get; set; }
    
        public virtual Students Students { get; set; }
        public virtual Subject Subject1 { get; set; }
    }
}
