using Ejercicio.Models.Entidades;

namespace Ejercicio.Services
{
    public interface IServicioEditorial
    {
        Task<Editorial> SaveEditorial(Editorial editorial);
        Task<Editorial> GetEditorial(string nombreEdi);
    }
}
