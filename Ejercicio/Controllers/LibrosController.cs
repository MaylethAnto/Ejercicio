using Ejercicio.Models;
using Ejercicio.Models.entidades;
using Ejercicio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ejercicio.Controllers
{
    public class LibrosController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;
        private readonly IServicioImagen _servicioImagen;
        private readonly IServicioLista _servicioLista;
        private readonly LibreriaContext _context;

        public LibrosController(IServicioUsuario servicioUsuario, IServicioImagen servicioImagen, IServicioLista servicioLista, LibreriaContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioImagen = servicioImagen;
            _servicioLista = servicioLista;
            _context = context;
        }

        public async Task<IActionResult> Lista() 
        {
            return View(await _context.Libros
                .Include(l => l.Categoria)
                .Include(l => l.Autor)
                .ToListAsync());
        }
        public async Task<IActionResult> Crear() 
        {
            Libro libro = new Libro()
            {
                Categorias = await _servicioLista.GetListaCategorias(),
                Autores = await _servicioLista.GetListaAutores()
            };
            return View(libro);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Libro libro, IFormFile Imagen) 
        {
            if (ModelState.IsValid)
            {
                Stream imagen = Imagen.OpenReadStream();
                String urllibro = await _servicioImagen.SubirImagen(imagen, Imagen.Name);

                libro.URLlibro = urllibro;
                _context.Add(libro);
                await _context.SaveChangesAsync();
                TempData["AlerMessage"] = "Libro creado exitosamente";
                return RedirectToAction("Lista");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "ha ocurrido un error");
            }
            libro.Categorias = await _servicioLista.GetListaCategorias();
            libro.Autores = await _servicioLista.GetListaAutores();
            return View(libro);
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }
            libro.Categorias = await _servicioLista.GetListaCategorias();
            libro.Autores = await _servicioLista.GetListaAutores();
            return View(libro);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Libro libro, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var libroexistente = await _context.Libros.FindAsync(libro.idlibro);
                    if (libroexistente == null)
                    {
                        return NotFound();
                    }
                    if (Imagen != null)
                    {
                        Stream image = Imagen.OpenReadStream();
                        string URLlibro = await _servicioImagen.SubirImagen(image, Imagen.Name);
                        libroexistente.URLlibro = URLlibro;
                    }
                    libroexistente.Titulo = libro.Titulo;
                    libroexistente.Autor = await _context.Autores.FindAsync(libro.AutorId);
                    libroexistente.Categoria = await _context.Categorias.FindAsync(libro.CategoriaId);
                    libroexistente.Año = libro.Año;
                    libroexistente.Precio = libro.Precio;

                    _context.Update(libroexistente);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Libro Actualizado Exitosamente";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {
                    TempData["AlertMessage"] = ex;
                    return RedirectToAction("Lista");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "ha ocuddido un error");
            }
            return View();
        }
    }
}
