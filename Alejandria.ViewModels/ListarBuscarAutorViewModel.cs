using Alejandria.Models;

namespace Alejandria.ViewModels
{
    public class ListarBuscarAutorViewModel
    {
        public IQueryable<Autor>? Autores { get; set; }
        public Autor? Autor { get; set; }
        public string? NombreBuscar { get; set; }
    }
}
