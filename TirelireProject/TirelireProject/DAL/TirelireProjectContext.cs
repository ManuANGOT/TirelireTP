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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
         .Ignore(c => c.PaymentOrder);

            // Configuration de la relation entre ShoppingCart et Customer
            modelBuilder.Entity<ShoppingCart>()
                        .HasOne(sc => sc.Customer)
                        .WithMany(c => c.ShoppingCarts)
                        .HasForeignKey(sc => sc.CustomerId);

            // Configuration de la relation entre ShoppingCart et PaymentOrder
            modelBuilder.Entity<ShoppingCart>()
                        .HasOne(sc => sc.PaymentOrder) // Un panier peut avoir un PaymentOrder (optionnel)
                        .WithOne()
                        .HasForeignKey<ShoppingCart>(s => s.PaymentOrderId); // Clé étrangère dans ShoppingCart

            // Coonfiguration vlidation/paiement du panier
            modelBuilder.Entity<PaymentOrder>()
                        .HasOne(po => po.ShoppingCart)
                        .WithOne(sc => sc.PaymentOrder)
                        .HasForeignKey<PaymentOrder>(po => po.ShoppingCartId);
        }

        public DbSet<TirelireProject.Models.Product> Product { get; set; } = default!;

        public DbSet<TirelireProject.Models.Customer>? Customer { get; set; }

        public DbSet<TirelireProject.Models.Role>? Role { get; set; }

        public DbSet<TirelireProject.Models.ShoppingCart>? ShoppingCart { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<PaymentOrder> PaymentOrders { get; set; }
    }
}
