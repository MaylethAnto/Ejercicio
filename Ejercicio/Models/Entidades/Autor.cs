using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Autor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAutor { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nomAutor { get; set; }
        public string apAutor { get; set; }

    }
}
