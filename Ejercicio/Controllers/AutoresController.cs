using Ejercicio.Models;
using Ejercicio.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Controllers
{
    public class AutoresController : Controller
    {

        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public AutoresController(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListadoAutores()
        {
            return View(await _context.Autores.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Autor autor)
        {
            if(ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Autor creado exitosamente";
                return RedirectToAction("ListadoAutores");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");

            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Editar(int ?id)
        {
            if(id == null || _context.Autores == null )
            {
                return NotFound();
            }
            var autor = await _context.Autores.FindAsync(id);

            if (autor ==null)
            {
                return NotFound();
            }
            return View(autor);
        }


        public async Task<IActionResult> Editar(int idAutor, Autor autor)
        {

            if (idAutor != autor.idAutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Autor Actualizado" + "exitosamente !!!";
                    return RedirectToAction("ListadoAutores");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un errror" + "Al actualizar");


                }
            }

            return View(autor);

        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id== null || _context.Autores == null)
            {
                return NotFound();
            }
            var autor = await _context.Autores
                .FirstOrDefaultAsync(a=> a.idAutor == id);

            if (autor == null) 
            {
                return NotFound();
            }

            try
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Autor Eliminado exitosamente !!!";
               

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");


            }
            return RedirectToAction(nameof(ListadoAutores));
        }
    }
}
