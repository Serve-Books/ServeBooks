using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ServeBooks.Data;
using ServeBooks.DTOs;
using ServeBooks.Models;
using ServeBooks.Services;
using Microsoft.IdentityModel.Tokens;

namespace Libreria.Sevices
{
    public class JwtRepository : IJwtRepository
    {
        private readonly DataContext _context;
        public JwtRepository(DataContext context)
        {
            _context = context;
        }

        public string GenerarToken(UsuarioDto Usuario)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mcjfnvjfnvhbvncfjccmkcc-nduxhdbhcbfhcbfhvcrvyecbcd@"));
            var Signing = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var TokenOptions = new JwtSecurityToken
            (
                issuer: "http://localhost:5242",
                audience: "http://localhost:5242",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: Signing
            );
            var TokenString = new JwtSecurityTokenHandler().WriteToken(TokenOptions);
            return TokenString;
        }
    }
}