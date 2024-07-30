using ServeBooks.DTOs;

namespace ServeBooks.Services
{
    public interface IJwtRepository 
    {
        String GenerarToken(UsuarioDto Usuario);
    }
}