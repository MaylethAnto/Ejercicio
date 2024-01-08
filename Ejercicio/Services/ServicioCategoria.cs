using Ejercicio.Models;
using Ejercicio.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Services
{
    public class ServicioCategoria : IServicioCategoria
    {
        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public ServicioCategoria(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoria(string categoria)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.categoria== categoria);
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
        {

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }
    }
}
