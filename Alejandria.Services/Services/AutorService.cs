using Alejandria.Interfaces.IRepositories;
using Alejandria.Interfaces.IServices;
using Alejandria.Models;

namespace Alejandria.Services.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        public async Task<IQueryable<Autor>> Listar()
        {
            IQueryable<Autor> autores = await _autorRepository.Listar();
            return autores;
        }
        public void Crear(Autor autor)
        {
            _autorRepository.Crear(autor);
        }
        public void Actualizar(Autor autor)
        {
            _autorRepository.Actualizar(autor);
        }
        public async Task<bool> Eliminar(int Id)
        {
            await _autorRepository.Eliminar(Id);
            return true;
        }
        public async Task<IQueryable<Autor>> BuscarPorNombre(string nombre)
        {
            return await _autorRepository.BuscarPorNombre(nombre);
        }
    }
}

