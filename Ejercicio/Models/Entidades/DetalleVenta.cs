using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using proyectoclase.Models.entidades;

namespace Ejercicio.Models.Entidades
{
    public class DetalleVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

       

        public int iddetalleventa { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int cantidadlibros { get; set; }
        public Ventas ventas { get; set; }
        public Libro libro { get; set; }
    }
}
