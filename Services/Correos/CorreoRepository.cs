using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using ServeBooks.Services.Correos;
using ServeBooks.DTOs;


namespace ServeBooks.Services.Correos
{
	public class CorreoRepository(IConfiguration config) : ICorreoRepository
	{
		private readonly IConfiguration _config = config;

		public void SendEmail(CorreoDTO correoDTO)
		{
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
			email.To.Add(MailboxAddress.Parse(correoDTO.For));
			email.Subject = correoDTO.Affair;
			email.Body = new TextPart(TextFormat.Html)
			{
				Text = correoDTO.Content
			};

			using var smtp = new SmtpClient();
			smtp.Connect(
				_config.GetSection("Email:Host").Value,
				Convert.ToInt32(_config.GetSection("Email:Port").Value),
				SecureSocketOptions.StartTls
			);

			smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:Password").Value);

			smtp.Send(email);
			smtp.Disconnect(true);
		}

		public string CorreoRegistro(string CorreoUsuario)
		{
			CorreoDTO oCorreoDTO = new()
			{
				For = CorreoUsuario,
				Affair = "Registro exitoso",
				Content = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Verificación de Código</title>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                background-color: #f9f9f9;
                                padding: 20px;
                                margin: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 0 auto;
                                background-color: #ffffff;
                                padding: 30px;
                                border-radius: 10px;
                                box-shadow: 0 4px 8px rgba(0,0,0,0.1);
                                border-top: 10px solid #4CAF50;
                            }}
                            h1 {{
                                font-size: 24px;
                                color: #333333;
                            }}
                            p {{
                                font-size: 16px;
                                color: #666666;
                            }}
                            .verification-code {{
                                display: inline-block;
                                padding: 15px;
                                background-color: #e0f7fa;
                                border: 2px dashed #009688;
                                border-radius: 8px;
                                font-size: 20px;
                                color: #00796b;
                                margin-top: 20px;
                                text-align: center;
                            }}
                            .footer {{
                                margin-top: 30px;
                                font-size: 14px;
                                color: #aaaaaa;
                                text-align: center;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class=""container"">
                            <h1>¡Gracias por preferirnos!</h1>
                            <div class=""verification-code"">Leer alimenta el alma</div>
                            <div class=""footer"">
                                <p>el usuario {CorreoUsuario} fue registrado</p>
                                <p>&copy; 2024 Serve books. Todos los derechos reservados.</p>
                            </div>
                        </div>
                    </body>
                    </html>
                    "
			};
			SendEmail(oCorreoDTO);

			return "Codigo enviado correctamente";
		}

		public string CorreoInicio(string CorreoUsuario, string ip)
        {
			CorreoDTO oCorreoDTO = new()
			{
				For = CorreoUsuario,
				Affair = "Nuevo inicio de sesión",
				Content = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Verificación de Código</title>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                background-color: #f9f9f9;
                                padding: 20px;
                                margin: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 0 auto;
                                background-color: #ffffff;
                                padding: 30px;
                                border-radius: 10px;
                                box-shadow: 0 4px 8px rgba(0,0,0,0.1);
                                border-top: 10px solid #4CAF50;
                            }}
                            h1 {{
                                font-size: 24px;
                                color: #333333;
                            }}
                            p {{
                                font-size: 16px;
                                color: #666666;
                            }}
                            .verification-code {{
                                display: inline-block;
                                padding: 15px;
                                background-color: #e0f7fa;
                                border: 2px dashed #009688;
                                border-radius: 8px;
                                font-size: 20px;
                                color: #00796b;
                                margin-top: 20px;
                                text-align: center;
                            }}
                            .footer {{
                                margin-top: 30px;
                                font-size: 14px;
                                color: #aaaaaa;
                                text-align: center;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class=""container"">
                            <h1>Sesion iniciada</h1>
                            <div class=""verification-code"">Se ha registrado un nuevo inicio de sesion en su cuenta</div>
                            <div class=""footer"">
                                <p>Se registro un inicio desde la ip {ip}</p>
                                <p>&copy; 2024 Serve books. Todos los derechos reservados.</p>
                            </div>
                        </div>
                    </body>
                    </html>
                    "
			};
			SendEmail(oCorreoDTO);

			return "Codigo enviado correctamente";
		}

        public string CorreoSolicitudPrestamo(string CorreoUsuario, string NombreLibro)
        {
			CorreoDTO oCorreoDTO = new()
			{
				For = CorreoUsuario,
				Affair = "Solicitud de prestamo",
				Content = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Verificación de Código</title>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                background-color: #f9f9f9;
                                padding: 20px;
                                margin: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 0 auto;
                                background-color: #ffffff;
                                padding: 30px;
                                border-radius: 10px;
                                box-shadow: 0 4px 8px rgba(0,0,0,0.1);
                                border-top: 10px solid #4CAF50;
                            }}
                            h1 {{
                                font-size: 24px;
                                color: #333333;
                            }}
                            p {{
                                font-size: 16px;
                                color: #666666;
                            }}
                            .verification-code {{
                                display: inline-block;
                                padding: 15px;
                                background-color: #e0f7fa;
                                border: 2px dashed #009688;
                                border-radius: 8px;
                                font-size: 20px;
                                color: #00796b;
                                margin-top: 20px;
                                text-align: center;
                            }}
                            .footer {{
                                margin-top: 30px;
                                font-size: 14px;
                                color: #aaaaaa;
                                text-align: center;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class=""container"">
                            <h1>Solicitud de prestamo exitos</h1>
                            <div class=""verification-code"">Se ha realizado la solicitud del prestamo exitosamente del libro {NombreLibro}</div>
                            <div class=""footer"">
                                <p>Nos estaremos comunicando por este medio para darle mas informacion</p>
                                <p>&copy; 2024 Serve books. Todos los derechos reservados.</p>
                            </div>
                        </div>
                    </body>
                    </html>
                    "
			};
			SendEmail(oCorreoDTO);

			return "Codigo enviado correctamente";
		}

        public string CorreoAutorizcionPrestamo(string CorreoUsuario, string NombreLibro)
        {
			CorreoDTO oCorreoDTO = new()
			{
				For = CorreoUsuario,
				Affair = "Respuesta solicitud del prestamo",
				Content = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Verificación de Código</title>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                background-color: #f9f9f9;
                                padding: 20px;
                                margin: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 0 auto;
                                background-color: #ffffff;
                                padding: 30px;
                                border-radius: 10px;
                                box-shadow: 0 4px 8px rgba(0,0,0,0.1);
                                border-top: 10px solid #4CAF50;
                            }}
                            h1 {{
                                font-size: 24px;
                                color: #333333;
                            }}
                            p {{
                                font-size: 16px;
                                color: #666666;
                            }}
                            .verification-code {{
                                display: inline-block;
                                padding: 15px;
                                background-color: #e0f7fa;
                                border: 2px dashed #009688;
                                border-radius: 8px;
                                font-size: 20px;
                                color: #00796b;
                                margin-top: 20px;
                                text-align: center;
                            }}
                            .footer {{
                                margin-top: 30px;
                                font-size: 14px;
                                color: #aaaaaa;
                                text-align: center;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class=""container"">
                            <h1>Respuesta solicitud</h1>
                            <div class=""verification-code"">Su solictud por el prestamo del libro {NombreLibro} fue aprobada exitosamente</div>
                            <div class=""footer"">
                                <p>Puede pasar a recoger su libro con un plazo maximo de 24 horas</p>
                                <p>&copy; 2024 Serve books. Todos los derechos reservados.</p>
                            </div>
                        </div>
                    </body>
                    </html>
                    "
			};
			SendEmail(oCorreoDTO);

			return "Codigo enviado correctamente";
		}
	}
}