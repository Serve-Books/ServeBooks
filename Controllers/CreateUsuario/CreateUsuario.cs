using Microsoft.AspNetCore.Mvc;
using ServeBooks.DTOs;
using ServeBooks.Models;
using ServeBooks.Services;
namespace ServeBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CreateUsuarioDto registroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Aquí podrías agregar lógica para verificar si el correo ya está registrado

            var usuario = new Usuario
            {
                Nombre = registroDto.Nombre,
                Apellido = registroDto.Apellido,
                DocumentoId = registroDto.DocumentoId,
                Numero_de_documento = registroDto.NumeroDeDocumento,
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
