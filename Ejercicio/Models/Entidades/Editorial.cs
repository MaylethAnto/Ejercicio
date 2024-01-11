using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Editorial
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idEditorial { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nombreEdi { get; set; }
      

    }
}
