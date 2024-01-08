using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRol { get; set; }

        [Required(ErrorMessage = "El campo {nombreRol} es obligatorio")]
        public string nombreRol { get; set; }
   
    }
}
