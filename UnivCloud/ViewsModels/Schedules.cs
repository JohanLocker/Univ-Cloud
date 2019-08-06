using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnivCloud.ViewsModels
{
    public class Schedules
    {
        public string ID_Schedules { get; set; }
        public TimeSpan HourStart { get; set; }
        public TimeSpan HourEnd { get; set; }
        [Required(ErrorMessage = "Es requerido el dia")]
        public string Day { get; set; }
        [Required(ErrorMessage = "Es requerido la Asignatura")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Es requerido el Profesor")]
        public string Professor { get; set; }
        [Required(ErrorMessage = "Es requerido el Aula")]
        public string Classroom { get; set; }

        public string GetID_Schedules()
        {
            /*DAY-SUBJECT-CLASSROOM*/
            /*LUN-MAT001-1*/
            string SubString = Day.Substring(0, 3).ToUpper();
            string Result = SubString + "-" + Subject + "-" + Classroom;
            return Result;
        }
    }
}