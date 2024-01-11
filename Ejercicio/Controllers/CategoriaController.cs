
using Ejercicio.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {

            var listCategoria = new List<Categoria>()
            {
                new Categoria
                {
                    idCategoria = 1,
                    categoria = "Comedia",
                    descripcion = "nadie ama a Calvin"
                },

                new Categoria
                {
                    idCategoria = 2,
                    categoria = "Terror",
                    descripcion = "BUUUUU"
                }

                };
            return View(listCategoria);
        }
    }
}

