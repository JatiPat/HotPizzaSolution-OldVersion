using HotPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace HotPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) :base(options) //with this, we can play with the options in program.cs
        {
               
        }

        public DbSet<Style> Styles { get; set; } //must be public to access in StyleController

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Method used to seed data into SQL
        {
            modelBuilder.Entity<Style>().HasData(
                new Style { Id = 1, Name= "New York", DisplayOrder = 1},
                  new Style { Id = 2, Name = "Chicago", DisplayOrder = 2 },
                    new Style { Id = 3, Name = "Detroit", DisplayOrder = 3 }
                );
        }
    }
}
