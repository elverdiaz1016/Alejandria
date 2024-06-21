namespace Alejandria.Models
{
    public class Autor
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public ICollection<Libro> Libros { get; } = new List<Libro>(); // Navegación de colección que contiene dependientes
    }
}
