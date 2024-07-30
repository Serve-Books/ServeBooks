using ServeBooks.Models;
using ServeBooks.Services.Libros;
using Microsoft.AspNetCore.Mvc;

namespace ServeBooks.Controllers.Libros
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroCreateController : ControllerBase
    {
        private readonly ILibrosRepository _librosRepository;

        public LibroCreateController(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        [HttpPost]
        public IActionResult AñadirLibro(Libro libro)
        {
            try
            {
                _librosRepository.AñadirLibro(libro);
                return Ok(libro);
            }
            catch (System.Exception)
            {
                return BadRequest("No se pudo añadir el libro");
            }
        }
    }
}