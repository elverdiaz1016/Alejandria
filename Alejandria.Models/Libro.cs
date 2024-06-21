namespace Alejandria.Models
{
    public class Libro
    {
        public long Id { get; set; }
        public String? Nombre { get; set; }
        public string? Categoria { get; set; }
        public int Precio { get; set; }
        public long? AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
    