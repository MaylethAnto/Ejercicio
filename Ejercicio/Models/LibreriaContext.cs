using Ejercicio.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Ejercicio.Models.entidades;

namespace Ejercicio.Models
{
    public class LibreriaContext : DbContext

    {
        public LibreriaContext()
        {

        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //Este metodo q va ayudar a conectar con la BDD
        {
            base.OnModelCreating(modelBuilder);
        }
    }


}

