using Ejercicio.Models.Entidades;

namespace Ejercicio.Services
{
    public interface IServicioCategoria
    {

        Task<Categoria> SaveCategoria(Categoria categoria);

        Task<Categoria> GetCategoria(string categoria);


    }
}