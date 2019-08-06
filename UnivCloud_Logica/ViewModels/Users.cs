using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnivCloud_Logica.ViewModels
{
    public class User
    {
        [Required(ErrorMessage = "Es requerido rellenar este campo")]
        [Display(Name = "Usuario")]
        public string UserLogin { get; set; }
        [Display(Name = "Contraseña")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Un minimo de 4 digitos en la contraseña")]
        public string PasswordLogin { get; set; }
    }
    public class RegisterUser
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo solo acepta Codigo del empleado")]
        public string Employee { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Caracter no permitido, Asegurese de no ingresar numericos o especiales.")]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Las contraseñas no son identicas")]
        public string Confirm { get; set; }
    }
    public class ControlPanel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Privileges { get; set; }
    }
}