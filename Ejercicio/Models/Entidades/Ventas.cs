using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ejercicio.Models.Entidades;

namespace proyectoclase.Models.entidades
{
    public class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int idVentas { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Column(TypeName = "decimal (18,2)")]             //Sentencia para los campos que son decimales
        [DisplayFormat(DataFormatString = "{0:c2}")]

        public decimal subtotal { get; set; }

        [Column(TypeName = "decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal descuento { get; set; }

        [Column(TypeName = "decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal iva { get; set; }

        [Column(TypeName = "decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal total { get; set; }

        public DateTime fechaventa { get; set; }
        public Usuario usuario { get; set; }  //Clave Foranea
    }
}
