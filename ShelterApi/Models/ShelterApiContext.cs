using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Models
{
  public class ShelterApiContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }

    public ShelterApiContext(DbContextOptions<ShelterApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Salmon", Species = "Cat", Breed = "Scottish Fold", Age = 7 },
          new Animal { AnimalId = 2, Name = "Andre", Species = "Dog", Breed = "King Charles Cavalier", Age = 12 },
          new Animal { AnimalId = 3, Name = "Sid", Species = "Dog", Breed = "Dalmatian", Age = 2 },
          new Animal { AnimalId = 4, Name = "Blade", Species = "Cat", Breed = "Ragdoll", Age = 4 },
          new Animal { AnimalId = 5, Name = "Baby", Species = "Dog", Breed = "Rotweiller", Age = 2 }
        );
    }
  }
}