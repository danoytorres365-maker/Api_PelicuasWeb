using Microsoft.EntityFrameworkCore;
using PeliculasApi5.Entidades;

namespace PeliculasApi5
{
    public class ApplicationDbContext:DbContext

    {

       /* public ApplicationDbContext()
        {

        }*/

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        

        public DbSet<Genero> Generos {get; set;}
    }
}






