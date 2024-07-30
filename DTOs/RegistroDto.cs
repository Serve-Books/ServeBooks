using System.ComponentModel.DataAnnotations;

namespace ServeBooks.DTOs
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public int DocumentoId { get; set; }

        [Required]
        public string Numero_de_documento { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Rol { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}
