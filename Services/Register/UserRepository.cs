// using ServeBooks.Data;
// using ServeBooks.Models;
// using ServeBooks.Services;

// namespace ServeBooks.Servives
// {
//     public class UsuarioRepository : IUsuarioRepository
//     {
//         private readonly DataContext _context;
//         public UsuarioRepository(DataContext context)
//         {
//             _context = context;
//         }
//         public Task<bool> CrearUsuario(Usuario usuario)
//         {
//             try 
//             {
//                 _context.Usuarios.Add(usuario);
//                 await _context.SaveChangesAsync();
//                 return true;
//             }          
//             catch (Exception ex)
//             {
//                 return false;
//             }
//         }
//     }
// }using Microsoft.EntityFrameworkCore;
using ServeBooks.Data;
using ServeBooks.Models;
using System;
using System.Threading.Tasks;
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

        public Task<bool> CrearUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CrearUsuarioAsync(Usuario usuario)
        {
            // Validar que el usuario y la contraseña no sean nulos o vacíos
            if (usuario == null || string.IsNullOrEmpty(usuario.Contraseña))
            {
                return false;
            }

            // Cifra la contraseña antes de guardarla en la base de datos
            usuario.Contraseña = HashPassword(usuario.Contraseña);

            try
            {
                // Añadir el usuario a la base de datos
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: registrar el error y retornar false
                // Aquí puedes usar un logger para registrar detalles de la excepción
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
