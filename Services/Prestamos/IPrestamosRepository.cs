using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeBooks.Models;


namespace ServeBooks.Services.Prestamos
{
    public interface IPrestamosRepository
    {
        void CrearPrestamo(Prestamo prestamo);
    }
}