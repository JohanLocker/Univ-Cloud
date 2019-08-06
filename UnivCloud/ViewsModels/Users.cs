using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnivCloud
{
    public class User
    {
        [Required(ErrorMessage ="Es requerido rellenar este campo")]
        [Display(Name ="Usuario")]
        public string UserLogin { get; set; }
        [Display(Name ="Contraseña")]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="Un minimo de 4 digitos en la contraseña")]
        public string PasswordLogin { get; set; }
    }
    public class RegistroUsuario
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo solo acepta Codigo del empleado")]
        public string Empleado { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage ="Caracter no permitido, Asegurese de no ingresar numericos o especiales.")]
        [Display(Name ="Usuario")]
        public string UsuarioR { get; set; }
        
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [Display(Name = "Contraseña")]
        public string ContrasenaR { get; set; }

        [Compare("ContrasenaR", ErrorMessage ="Las contraseñas no son identicas")]
        public string Confirmar { get; set; }
    }
    public class ChangePassword
    {
        [Display(Name ="Contraseña Actual")]
        [Required(ErrorMessage ="Es obligatorio este campo para cambiar la contraseña")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Es obligatorio este campo para cambiar la contraseña")]
        [Display(Name = "Contraseña Nueva")]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage ="Las contraseña no son identicas")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }
    }
    public class StateValid
    {
        public bool? States { get; set; }
        public string Message { get; set; }
    }
    public class CreateUser
    {
        public string CodeEmployee { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Privileges { get; set; }
    }
}