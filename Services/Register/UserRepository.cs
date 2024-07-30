using ServeBooks.Data;
using ServeBooks.Models;
using BCrypt.Net;

namespace ServeBooks.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearUsuarioAsync(Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Contraseña))
            {
                return false;
            }
            usuario.Contraseña = HashPassword(usuario.Contraseña);

            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return false;
            }
        }

        private string HashPassword(string plainTextPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword))
            {
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(plainTextPassword));
            }

            // Utilizamos BCrypt para generar un hash de la contraseña
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }
    }
}
