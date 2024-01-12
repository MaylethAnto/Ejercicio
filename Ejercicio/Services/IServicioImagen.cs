namespace Ejercicio.Services
{
    public interface IServicioImagen
    {
        Task<string> SubirImagen(Stream archivo, string nombre);
    }
}
