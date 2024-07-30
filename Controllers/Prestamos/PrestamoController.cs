using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServeBooks.Services.Prestamos;
using ServeBooks.Models;


namespace ServeBooks.Controllers.Prestamos
{
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamosRepository _prestamos;

        public PrestamoController(IPrestamosRepository prestamos)
        {
            _prestamos = prestamos;
        }
        
        [HttpPost]
        [Route("Prestamo/Creado")]
        public IActionResult CrearPrestamo(Prestamo prestamo)
        {
            try
            {
                _prestamos.CrearPrestamo(prestamo);
                return Ok(prestamo);
            }
            catch (System.Exception)
            {
                return BadRequest("No se puede crear el prestamo");
            }
        }
    }
}