using Ejercicio.Models.Entidades;


namespace Ejercicio.Services
{
    public interface IServicioAutor
    {

        Task<Autor> SaveAutor(Autor autor);

        Task<Autor> GetAutor(string nomAutor, string apAutor);


    }
}