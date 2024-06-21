using Alejandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alejandria.DataAccess
{
    public class AlejandriaDbContext : DbContext
    {
        public AlejandriaDbContext(DbContextOptions<AlejandriaDbContext> options)
            : base(options) { }

        public DbSet<Libro> Libros => Set<Libro>();
        public DbSet<Autor> Autores => Set<Autor>();

    }
}
