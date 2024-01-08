using Ejercicio.Models.Entidades;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoclase.Models.entidades
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idlibro { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string titulo { get; set; }

        public int año { get; set; }

        public bool estado { get; set; }

        [Column(TypeName = "decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal precio { get; set; }


        public DateTime fecharegistro { get; set; }

        public string urllibro { get; set; }


        //Claves foráneas

        public Autor autor { get; set; }
        public Categoria categoria { get; set; }

        public Editorial editorial { get; set; }
    }
}
