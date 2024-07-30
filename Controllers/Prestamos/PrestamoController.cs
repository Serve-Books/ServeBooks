using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IActionResult CrearPrestamo([FromBody]Prestamo Prestamos)
        {
            try
            {
                _prestamos.CrearPrestamo(Prestamos);
                return Ok("Funciona");
            }
            catch (System.Exception)
            {
                return BadRequest("No se puede crear el prestamo");
            }
        }
    }
}