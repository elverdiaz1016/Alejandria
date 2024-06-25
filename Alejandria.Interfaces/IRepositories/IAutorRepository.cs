using Alejandria.Models;

namespace Alejandria.Interfaces.IRepositories
{
    public interface IAutorRepository
    {
        Task<IQueryable<Autor>> Listar();
        Task<bool> Eliminar(int id);
        void Crear(Autor autor);
        void Actualizar(Autor autor);
        Task<IQueryable<Autor>> BuscarPorNombre(string nombre);
    }
}
    