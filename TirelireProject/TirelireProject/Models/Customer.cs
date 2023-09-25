using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TirelireProject.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Le nom du client est requis.")]
        [StringLength(50, ErrorMessage = "Le nom du client ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le prénom du client est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom du client ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "La date de naissance du client est requise.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "L'email du client est requis.")]
        [StringLength(100, ErrorMessage = "L'email du client doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Le mot de passe du client est requis.")]
        [StringLength(100, ErrorMessage = "Le mot de passe du client doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

        public ShoppingCart ShoppingCart { get; set; }

        public int? PaymentOrderId { get; set; }


        [NotMapped]
        public PaymentOrder PaymentOrder { get; set; }

        public void AddToCart(Product product, int quantity)
        {
            {   // Création nouveau panier
                if (ShoppingCart == null)
                {
                    ShoppingCart = new ShoppingCart(); 
                }

                // Vérifiez si le produit est déjà dans le panier
                var existingCartItem = ShoppingCart.CartItems.FirstOrDefault(item => item.Product.ProductId == product.ProductId);

                if (existingCartItem != null)
                {
                    // Si le produit est déjà dans le panier, augmentez simplement la quantité
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    ShoppingCart.CartItems.Add(new CartItem
                    {
                        Product = product,
                        Quantity = quantity
                    });
                }

                // logique pour calculer le total du panier, les frais de livraison, etc.
            }
        }
        public void RemoveFromCart(Product product)
        {
            // logique pour retirer un produit du panier
        }
    }
}
