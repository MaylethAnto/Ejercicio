using Ejercicio.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Controllers
{
    public class AutorController : Controller
    {
        public IActionResult Index()
        {
            var autor = new Autor();
            autor.idAutor = 1;
            autor.nomAutor = "Mayleth - David";
            autor.apAutor = "Conforme - Andocilla";

            return View(autor);
        }
        
    }
}
