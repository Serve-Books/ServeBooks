using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServeBooks.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int AutorId { get; set; }
        public DateTime Fecha_de_publicación { get; set; }
        public int Numero_de_copias { get; set; }
        public int GeneroId { get; set; }
        public string Estado { get; set; } = null!;
    }
}