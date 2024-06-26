using Alejandria.Models;

namespace Alejandria.Interfaces.IServices
{
    public interface IAutorService
    {
        Task<IQueryable<Autor>> Listar();
        void Crear(Autor autor);
        Task<bool> Eliminar(int Id);
        void Actualizar(Autor autor);
        Task<IQueryable<Autor>> BuscarPorNombre(string nombre);
    }
}
