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
    public class PrestamoMostrarController : ControllerBase
    {
        private readonly IPrestamosRepository _prestamos;

        public PrestamoMostrarController(IPrestamosRepository prestamos)
        {
            _prestamos = prestamos;
        }


        [HttpGet]
        [Route("Prestamos/Mostrados")]
        public IActionResult MostrarPrestamos()
        {
            return Ok(_prestamos.MostrarPrestamos());
        }

        
        [HttpGet("{id}")]
        public IActionResult MostrarPrestamo(int id)
        {
            return Ok(_prestamos.MostrarPrestamo(id));
        }

    }
}