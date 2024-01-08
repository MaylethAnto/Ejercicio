using Ejercicio.Models;
using Ejercicio.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Services
{
    public class ServicioAutor : IServicioAutor
    {
        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public ServicioAutor(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Autor> GetAutor(string nomAutor, string apAutor)
        {
            return await _context.Autores.FirstOrDefaultAsync(a => a.nomAutor == nomAutor && a.apAutor==apAutor);
        }

        public async Task<Autor> SaveAutor(Autor autor)
        {

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;

        }
    }
}
