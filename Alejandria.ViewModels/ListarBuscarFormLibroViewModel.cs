using Alejandria.Models;

namespace Alejandria.ViewModels
{
    public class ListarBuscarFormLibroViewModel
    {
        public IQueryable<Autor>? Autores { get; set; }
        public Libro? Libro { get; set; }

        public IQueryable<Libro>? Libros { get; set; }
        public string? NombreBuscar { get; set; }
    }
}
