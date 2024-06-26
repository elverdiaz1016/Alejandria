using Alejandria.Interfaces.IRepositories;
using Alejandria.Interfaces.IServices;
using Alejandria.Models;

namespace Alejandria.Services.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }
        public async Task<IQueryable<Libro>> Listar()
        {
            IQueryable<Libro> libros = await _libroRepository.Listar();
            return libros;
        }
        public void Crear(Libro libro)
        {
            _libroRepository.Crear(libro);
        }
        public async Task<bool> Eliminar(int Id)
        {
            await _libroRepository.Eliminar(Id);
            return true;
        }
        public async void Actualizar(Libro libro)
        {
            _libroRepository.Actualizar(libro);
        }
        public async Task<IQueryable<Libro>> BuscarPorNombre(string nombre)
        {
            return await _libroRepository.BuscarPorNombre(nombre);
        }
    }
}
