using Ejercicio.Models.Entidades;

namespace Ejercicio.Services
{
    public interface IServicioUsuario
    {


        Task<Usuario> GetUsuario(String correo, string contraseña);

        Task<Usuario> SaveUsuario(Usuario usuario);

        Task<Usuario> GetUsuario(string nomUsuario);


    }
}
