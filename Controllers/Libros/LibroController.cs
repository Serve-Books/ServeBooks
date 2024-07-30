using ServeBooks.Models;
using ServeBooks.Services.Libros;
using Microsoft.AspNetCore.Mvc;

namespace ServeBooks.Controllers.Libros
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibrosRepository _librosRepository;

        public LibroController(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        [HttpGet]
        public IActionResult ObtenerLibros()
        {
            return Ok(_librosRepository.ObtenerLibros());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerLibro(int id)
        {
            return Ok(_librosRepository.ObtenerLibro(id));
        }
    }
}