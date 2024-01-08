using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models.Entidades
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCategoria { get; set;}

        [Required(ErrorMessage = "El campo {categoria} es obligatorio")]
        public string categoria { get; set;}
        public string descripcion { get; set;}


    }
}
