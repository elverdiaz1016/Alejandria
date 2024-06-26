using Alejandria.Interfaces.IRepositories;
using Alejandria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Interfaces.IServices
{
    public interface ILibroService
    {
        Task<IQueryable<Libro>> Listar();
        void Crear(Libro libro);
        Task<bool> Eliminar(int Id);
        void Actualizar(Libro libro);
        Task<IQueryable<Libro>> BuscarPorNombre(string nombre);
    }
}
