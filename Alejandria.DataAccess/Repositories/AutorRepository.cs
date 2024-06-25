using Alejandria.Interfaces.IRepositories;
using Alejandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alejandria.DataAccess.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private AlejandriaDbContext _context;
        public AutorRepository(AlejandriaDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Autor>> Listar()
        {
            IQueryable<Autor> autores = _context.Autores.Include(x => x.Libros);
            return await Task.FromResult(autores);
        }
        public async void Crear(Autor autor)
        {
            await _context.AddAsync(autor);
            _context.SaveChanges();
        }
        public void Actualizar(Autor autor)
        {
            _context.Autores.Update(autor);
            _context.SaveChanges();
        }
        public async Task<bool> Eliminar(int Id)
        {
            Autor? autor = _context.Autores.FirstOrDefault(autor => autor.Id == Id);
            if (autor is null)
            {
                return false;
            }
            else
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<IQueryable<Autor>> BuscarPorNombre(string nombre)
        {

            IQueryable<Autor> autores = _context.Autores;

            if (!string.IsNullOrEmpty(nombre))
            {
                IQueryable<Autor> autoresTemp = _context.Autores.Where(autor => autor.Nombre!.Contains(nombre));
                autores = autoresTemp;
            }

            return await Task.FromResult(autores);
        }
    }
}
