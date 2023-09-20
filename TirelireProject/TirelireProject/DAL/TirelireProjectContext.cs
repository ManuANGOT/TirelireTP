using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TirelireProject.Models;

namespace TirelireProject.Data
{
    public class TirelireProjectContext : DbContext
    {
        public TirelireProjectContext (DbContextOptions<TirelireProjectContext> options)
            : base(options)
        {
        }

        public DbSet<TirelireProject.Models.Product> Product { get; set; } = default!;

        public DbSet<TirelireProject.Models.Customer>? Customer { get; set; }

        public DbSet<TirelireProject.Models.Role>? Role { get; set; }

        public DbSet<TirelireProject.Models.ShoppingCart>? ShoppingCart { get; set; }
    }
}
