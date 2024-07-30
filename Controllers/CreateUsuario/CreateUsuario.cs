using Microsoft.AspNetCore.Mvc;
using ServeBooks.Data;
using ServeBooks.DTOs;
using ServeBooks.Models;
using ServeBooks.Services;
namespace ServeBooks.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly DataContext _context;

        public UsuarioController(IUsuarioRepository usuarioRepository, DataContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CreateUsuarioDto registroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = new Usuario
            {
                Nombre = registroDto.Nombre,
                Apellido = registroDto.Apellido,
                DocumentoId = registroDto.DocumentoId,
                Numero_de_documento = registroDto.Numero_de_documento,
                Direccion = registroDto.Direccion,
                Telefono = registroDto.Telefono,
                Correo = registroDto.Correo,
                Rol = registroDto.Rol,
                Contraseña = registroDto.Contraseña
            };

            var resultado = await _usuarioRepository.CrearUsuarioAsync(usuario);

            if (resultado)
            {
                return Ok("Usuario registrado exitosamente.");
            }
            else
            {
                return StatusCode(500, "Hubo un problema al registrar el usuario.");
            }
        }
    }
}
