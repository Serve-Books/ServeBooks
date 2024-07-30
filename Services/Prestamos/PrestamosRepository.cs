using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServeBooks.Models;
using ServeBooks.Data;

namespace ServeBooks.Services.Prestamos
{
    public class PrestamosRepository : IPrestamosRepository
    {
        private readonly DataContext _context;

        public PrestamosRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Prestamo> MostrarPrestamos()
        {
            return _context.Prestamos;
        }

        public Prestamo MostrarPrestamo(int id)
        {
            return _context.Prestamos.Find(id);
        }

        public async Task<Prestamo> CrearPrestamo(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }
    }
}
