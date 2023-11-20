using HotPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace HotPizza.DataAccess.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) :base(options) //with this, we can play with the options in program.cs
        {
               
        }

        public DbSet<Style> Styles { get; set; } //must be public to access in StyleController
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Method used to seed data into SQL
        {
            modelBuilder.Entity<Style>().HasData(
                new Style { Id = 1, Name= "New York", DisplayOrder = 1},
                  new Style { Id = 2, Name = "Chicago", DisplayOrder = 2 },
                    new Style { Id = 3, Name = "Detroit", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Pizza>().HasData(
              new Pizza { Id = 1, Name = "Five Cheese Pizza", Description = " Mozzarella , Feta, Parmesan, Cheddar, and Ricotta", Price= 19.20, StyleId = 1, CompanyId =1 },
                new Pizza { Id = 2, Name = "Killer Veggie Pizza",  Description = " Green Pepper, Black Olives, and Sun Dried Tomatoes", Price = 13.50, StyleId = 2 , CompanyId = 2},
                  new Pizza { Id = 3, Name = "Ice Cream Pizza", Description ="Chocolate, Vanilla, or Strawberry", Price = 2.50, StyleId=3, CompanyId = 3 }
              );

            modelBuilder.Entity<Company>().HasData(
              new Company { Id = 1, Name = "Pizza Hut", },
                new Company { Id = 2, Name = "Romeo's", },
                  new Company { Id = 3, Name = "Papa Johns", }
              );
        }
    }
}
