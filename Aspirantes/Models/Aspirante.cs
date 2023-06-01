using System.ComponentModel.DataAnnotations;

namespace Aspirantes.Models
{
    public class Aspirante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El número telefónico es requerido")]
        public string NumTelefonico { get; set; }

        [Required(ErrorMessage = "El lugar de nacimiento es requerido")]
        public string LugarNacimiento { get; set; }
    }
}
