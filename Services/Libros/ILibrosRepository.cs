using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeBooks.Models;

namespace ServeBooks.Services.Libros
{
    public interface ILibrosRepository
    {
        IEnumerable<Libro> ObtenerLibros();
        Libro ObtenerLibro(int id);
        void AñadirLibro(Libro libro);
        void ActualizarLibro(Libro libro);
        void EliminarLibro(int id);
    }
}