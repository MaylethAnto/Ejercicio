using Ejercicio.Models;
using Ejercicio.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly LibreriaContext _context; //informacion de la libreria context de entidades

        public ServicioUsuario(LibreriaContext context)
        {
            _context = context;
        }


        public  async Task<Usuario> GetUsuario(string correo, string contraseña)
        {

            Usuario usuario = await _context.Usuarios.Where(u => u.correo == correo && u.password == contraseña).FirstOrDefaultAsync();

            return usuario;

        }

        public async Task<Usuario> GetUsuario(string nomUsuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.nomUsuario == nomUsuario);

        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }




    }
}
