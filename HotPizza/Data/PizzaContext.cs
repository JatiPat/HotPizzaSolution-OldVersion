using Microsoft.EntityFrameworkCore;

namespace HotPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) :base(options) //with this, we can play with the options in program.cs
        {
               
        }


    }
}
