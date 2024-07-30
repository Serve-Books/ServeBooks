using ServeBooks.Models;

namespace ServeBooks.Services 
{
    public interface IUsuarioRepository 
    {
        Task<bool> CrearUsuarioAsync (Usuario usuario);
    }
}