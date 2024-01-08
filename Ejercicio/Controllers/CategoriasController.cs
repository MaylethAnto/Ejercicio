using Ejercicio.Models;
using Ejercicio.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public CategoriasController(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListadoCategorias()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoria creado exitosamente";
                return RedirectToAction("ListadoAutores");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");

            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }


        public async Task<IActionResult> Editar(int idCategoria, Categoria categoria)
        {

            if (idCategoria != categoria.idCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Categoria Actualizado" + "exitosamente !!!";
                    return RedirectToAction("ListadoAutores");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un errror" + "Al actualizar");


                }
            }

            return View(categoria);

        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.idCategoria== id);

            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoria Eliminado exitosamente !!!";


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");


            }
            return RedirectToAction(nameof(ListadoCategorias));
        }
    }
}
