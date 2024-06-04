using Microsoft.EntityFrameworkCore;

namespace EjercicioClase3Modulo2EFCore;

public class ActorContext : DbContext
{
    public DbSet<Actor> Actores { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Actores;Trusted_Connection=True;");
    }
}
            

