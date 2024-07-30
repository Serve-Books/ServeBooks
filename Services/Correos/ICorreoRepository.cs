using ServeBooks.DTOs;

namespace ServeBooks.Services.Correos
{
	public interface ICorreoRepository
	{
		public void SendEmail(CorreoDTO correoDTO);

		public string CorreoRegistro(string CorreoUsuario);

		public string CorreoInicio(string CorreoUsuario, string ip);

		public string CorreoSolicitudPrestamo(string CorreoUsuario, string NombreLibro);

		public string CorreoAutorizcionPrestamo(string CorreoUsuario, string NombreLibro);

		public string CorreoRecordatio(string CorreoUsuario, string FechaLimite, string NombreLibro);
	
	}
}