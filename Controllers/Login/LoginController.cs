using ServeBooks.Data;
using ServeBooks.DTOs;
using ServeBooks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Controllers
{
    [ApiController]
    //[Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IJwtRepository _jwtRepository;
        public LoginController(DataContext context, IJwtRepository jwtRepository)
        {
            _context = context;
            _jwtRepository = jwtRepository;
        }
        [HttpPost("Login")]
        public async Task<IActionResult>Login ([FromBody] UsuarioDto Usuario)
        {
           try 
           {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == Usuario.Correo && u.Contraseña == Usuario.Contraseña);
              if (usuario == null)
            {
                return Unauthorized();
            }
            var token =_jwtRepository.GenerarToken(Usuario);
                return Ok(new{ Token = token});
            
           }
           catch (Exception ex)
           {
                return StatusCode(500, "Error al iniciar sesión");
 
           }
        }

        
    }
}