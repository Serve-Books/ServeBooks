using ServeBooks.Data;
using ServeBooks.DTOs;
using ServeBooks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServeBooks.Models;
using Microsoft.Extensions.Logging;


namespace ServeBooks.Controllers
{
    [ApiController]
    //[Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IJwtRepository _jwtRepository;
        private readonly ILogger<LoginController> _logger;
        public LoginController(DataContext context, IJwtRepository jwtRepository, ILogger<LoginController> logger)
        {
            _context = context;
            _jwtRepository = jwtRepository;
            _logger = logger;
        }
        [HttpPost("Login")]
        public async Task<IActionResult>Login ([FromBody] UsuarioDto Usuario)
        {
           try 
           {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == Usuario.Correo && u.Contraseña == Usuario.Contraseña);
                if (usuario == null)
                {
                 return Unauthorized("Correo o contraseña incorrectos");
                }
              if (String.IsNullOrEmpty(Usuario.Correo) || String.IsNullOrEmpty(Usuario.Contraseña))
              {
                 return BadRequest("Debe ingresar su correo y contraseña");
              }
                _logger.LogInformation($"Usuario encontrado: {Usuario.Correo}");
                _logger.LogInformation($"Contraseña encontrada: {Usuario.Contraseña}");

                var token =_jwtRepository.GenerarToken(Usuario);
                _logger.LogInformation($"Token encontrado: {token}");
                    return Ok(new{ Token = token}); 
           }
           catch (Exception ex)
           {
                return StatusCode(500, "Error al iniciar sesión");
 
           }
        }

        
    }
}