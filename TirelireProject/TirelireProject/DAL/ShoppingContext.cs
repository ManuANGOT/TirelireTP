using Microsoft.EntityFrameworkCore;

using TirelireProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TirelireProject.DAL
{
    public class ShoppingContext
    {
        public class SchoolContext : System.Data.Entity.DbContext
        {
            public System.Data.Entity.DbSet<Customer> Customers { get; set; }
            public System.Data.Entity.DbSet<Product> Products { get; set; }
            public System.Data.Entity.DbSet<ShoppingCart> ShoppingCarts { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    }
}
