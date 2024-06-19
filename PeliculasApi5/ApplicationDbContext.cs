using Microsoft.EntityFrameworkCore;
using PeliculasApi5.Entidades;

namespace PeliculasApi5
{
    public class ApplicationDbContext:DbContext


    {

       



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        public DbSet<Genero> Generos {get; set;}

        public DbSet<Actor> Actores { get; set; }
    }
}






