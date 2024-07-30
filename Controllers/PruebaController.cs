using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServeBooks.DTOs;
using ServeBooks.Services.Correos;

namespace ServeBooks.App.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PruebaController(ICorreoRepository correo) : ControllerBase
	{
		private readonly ICorreoRepository _correo = correo;

		[HttpGet]
		public IActionResult SendEmaill()
		{
			var res = _correo.CorreoRegistro("camicarva119@gmail.com");
			return Ok(res);
		}

		[HttpGet("ip")]
		public IActionResult GetClientIp()
		{
			var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;

			if (remoteIpAddress != null)
			{
				var res = _correo.CorreoInicio("camicarva119@gmail.com", remoteIpAddress.ToString());
				return Ok(res);
			}
			else
			{
				return BadRequest("Unable to determine the IP address.");
			}
		}

		[HttpGet("PrestamoLibro")]
		public IActionResult Prestamo()
		{
			var res = _correo.CorreoSolicitudPrestamo("camicarva119@gmail.com", "100 años de soledad");
			return Ok(res);
		}

		[HttpGet("RespuestaPrestamo")]
		public IActionResult SoliRes()
		{
			var res = _correo.CorreoSolicitudPrestamo("camicarva119@gmail.com", "100 años de soledad");
			return Ok(res);
		}


	}
}