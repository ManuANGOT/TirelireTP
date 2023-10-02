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
        public TirelireProjectContext(DbContextOptions<TirelireProjectContext> options)
       : base(options)
        {
        }

        public DbSet<TirelireProject.Models.Product> Product { get; set; } = default!;
        public DbSet<TirelireProject.Models.Customer>? Customer { get; set; }
        public DbSet<TirelireProject.Models.Admin>? Admin { get; set; }
        public DbSet<TirelireProject.Models.Mod>? Mod { get; set; }
        public DbSet<TirelireProject.Models.Assist>? Assist { get; set; }
        public DbSet<TirelireProject.Models.Role>? Role { get; set; }
        public DbSet<TirelireProject.Models.ShoppingCart>? ShoppingCart { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<Assist> Assists { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<PaymentOrder> PaymentOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relation entre Customer et ShoppingCart
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.ShoppingCarts)
                .WithOne(sc => sc.Customer)
                .HasForeignKey(sc => sc.CustomerId);

            // Relation entre ShoppingCart et PaymentOrder
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.PaymentOrder)
                .WithOne(po => po.ShoppingCart)
                .HasForeignKey<PaymentOrder>(po => po.ShoppingCartId);

            modelBuilder.Entity<PaymentOrder>()
                .HasOne(po => po.ShoppingCart)
                .WithOne(sc => sc.PaymentOrder)
                .HasForeignKey<PaymentOrder>(po => po.ShoppingCartId)
                .IsRequired(false);
        }
    }
}
