using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServeBooks.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}