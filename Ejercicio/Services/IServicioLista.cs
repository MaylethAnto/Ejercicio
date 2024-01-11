using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejercicio.Services
{
    public interface IServicioLista
    {

        Task<IEnumerable<SelectListItem>>
            GetListaAutores();

        Task<IEnumerable<SelectListItem>>
            GetListaCategorias();

        Task<IEnumerable<SelectListItem>>
         GetListaEditorial();

    }
}
