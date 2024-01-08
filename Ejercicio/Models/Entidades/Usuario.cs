using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int idUsuario { get; set; }
        public string nomUsuario { get; set; }

        [Required(ErrorMessage = "El campo {nomUsuario} es obligatorio")]
        public string cedula { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public string password { get; set; }

        public Roles roles { get; set; }
    }
}
