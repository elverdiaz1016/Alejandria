using Alejandria.Interfaces.IRepositories;
using Alejandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alejandria.DataAccess.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private AlejandriaDbContext _context; //Esta clase se encarga de interactuar con la base de datos a través de Entity Framework Core.
        public LibroRepository(AlejandriaDbContext ctx)
        {
            _context = ctx;
        }

        //le asigne la tabla libros a la variable libros a traves del dbcontext
        //basicamente con esto tenemos la tabla libros a la mano,
        //para ser usada en Services.
        public async Task<IQueryable<Libro>> Listar()
        {
            IQueryable<Libro> libros = _context.Libros.Include(x => x.Autor );
            return await Task.FromResult(libros);
        }

        public async void Crear(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            _context.SaveChanges();
        }

        public async Task<bool> Eliminar(int Id)
        {
            Libro? libro = _context.Libros.FirstOrDefault(libro => libro.Id == Id );

            if (libro is null)
            {
                return false;
            }
            else
            {
                 _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        public void Actualizar(Libro libro)
        {
            _context.Libros.Update(libro);
            _context.SaveChanges();
        }
        public async Task<IQueryable<Libro>> BuscarPorNombre(string nombre)
        {
            IQueryable<Libro> libros = _context.Libros.Include(x => x.Autor);
            if (!string.IsNullOrEmpty(nombre))
            {
                libros = _context.Libros.Where(libros => libros.Nombre!.Contains(nombre)).Include(x => x.Autor);
            }
            return await Task.FromResult(libros);
        }
        
}
    
}
