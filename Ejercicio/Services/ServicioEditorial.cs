using Ejercicio.Models.Entidades;
using Ejercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Services
{
    public class ServicioEditorial: IServicioEditorial
    {
        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public ServicioEditorial(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Editorial> GetEditorial(string nombreEdi)
        {
            return await _context.Editoriales.FirstOrDefaultAsync(a => a.nombreEdi == nombreEdi);
        }

        public async Task<Editorial> SaveEditorial(Editorial editorial)
        {

            _context.Editoriales.Add(editorial);
            await _context.SaveChangesAsync();
            return editorial;

        }
    }
}
