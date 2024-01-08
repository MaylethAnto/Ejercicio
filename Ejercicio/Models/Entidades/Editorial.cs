using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Editorial
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idEditorial { get; set; }

        [Required(ErrorMessage = "El campo {nombreEdi} es obligatorio")]
        public string nombreEdi { get; set; }
      

    }
}
