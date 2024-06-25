using Alejandria.Models;

namespace Alejandria.Interfaces.IRepositories
{
    public interface ILibroRepository
    {
        Task<IQueryable<Libro>> Listar();
        void Crear(Libro libro);
        Task<bool> Eliminar(int id);
        void Actualizar(Libro libro);
        Task<IQueryable< Libro>> BuscarPorNombre(string nombre);
    }
}
