using Ejercicio.Models.Entidades;
using Ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Controllers
{
    public class EditorialController : Controller
    {

        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public EditorialController(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListadoEditorial()
        {
            return View(await _context.Editoriales.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Editorial creado exitosamente";
                return RedirectToAction("ListadoEditorial");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");

            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.Editoriales.FindAsync(id);

            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int idEditorial, Editorial editorial)
        {

            if (idEditorial != editorial.idEditorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Editorial Actualizado" + "exitosamente !!!";
                    return RedirectToAction("ListadoEditorial");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un errror" + "Al actualizar");
                }
            }

            return View(editorial);

        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.Editoriales
                .FirstOrDefaultAsync(a => a.idEditorial == id);

            if (editorial == null)
            {
                return NotFound();
            }

            try
            {
                _context.Editoriales.Remove(editorial);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Editorial Eliminado exitosamente !!!";


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");


            }
            return RedirectToAction(nameof(ListadoEditorial));
        }
    }
}