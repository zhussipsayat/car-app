using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding State Master Data using HasData method
            modelBuilder.Entity<HColor>().HasData(
                new() { Id = 1, Name = "Red" },
                new() { Id = 2, Name = "Blue" },
                new() { Id = 3, Name = "Green" },
                new() { Id = 4, Name = "White" },
                new() { Id = 5, Name = "Black" }
            );
            //Seeding Country Master Data using HasData method
            modelBuilder.Entity<Car>().HasData(
               new() { Id = 1, BrandName = "BWM", ModelName = "X5 AMG", HColorId = 5 },
               new() { Id = 2, BrandName = "Mercedes", ModelName = "525 E-class", HColorId = 2 }
           );
        }

        public DbSet<HColor> HColors { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
