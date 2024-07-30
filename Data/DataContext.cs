using Microsoft.EntityFrameworkCore;
using ServeBooks.Models;

namespace ServeBooks.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}