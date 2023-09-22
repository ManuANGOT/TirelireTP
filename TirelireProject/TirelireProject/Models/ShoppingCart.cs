using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TirelireProject.Models;

namespace TirelireProject.Models
{
    public class ShoppingCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La date du panier est requise.")]
        [Display(Name = "Date du panier")]
        [DataType(DataType.DateTime)]
        public DateTime CartDate { get; set; }

 
        // Clé étrangère pour lier ShoppingCart au Customer
        public int CustomerId { get; set; } // id du client qui crée le panier
        public virtual Customer Customer { get; set; }


        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
       // Méthode pour calculer le total de la commande
        public decimal CalculateTotalCartItems()
        {
            decimal totalCartItem = 0;
            foreach (var cartItem in CartItems)
            {
                totalCartItem += cartItem.Product.ProductPrice * cartItem.Quantity;
            }
            return totalCartItem;
        }

        // Calcul des frais de livraison
        public decimal CalculateShipping()
        {
            // Calcul des frais de livraison (3€ par 1,5Kg)
            decimal totalWeight = 0;
            foreach (var cartItem in CartItems)
            {
                totalWeight += (decimal)(cartItem.Product.ProductWeight ?? 0) * cartItem.Quantity;
            }

            decimal shippingCost = Math.Ceiling(totalWeight / 1.5M) * 3M;
            return shippingCost;
        }

        [Display(Name = "Prix Total du panierHT")]
        public decimal CalculateTotalCartHT()
        {
            decimal totalCartHT = 0;

            // Calcul du total du panier HT en ajoutant le prix de chaque produit
            foreach (var cartItem in CartItems)
            {
                decimal productPrice = cartItem.Product.ProductPrice;
                int quantity = cartItem.Quantity;
                totalCartHT += (productPrice * quantity);
            }

            // Ajout des frais de livraison
            decimal shippingCost = CalculateShipping();
            totalCartHT += shippingCost;

            return totalCartHT;
        }

        [Display(Name = "Prix Total du panier TTC")]
        public decimal CalculateTotalCartTTC()
        {
            decimal totalCartHT = CalculateTotalCartHT();
            decimal tvaRate = 0.20m; // Taux de TVA de 20%

            // Calcul du total du panier TTC en appliquant le taux de TVA
            decimal totalCartTTC = totalCartHT * (1 + tvaRate);

            return totalCartTTC;
        }

        // Validation de la commande
        [Display(Name = "Le panier a été confirmé")]
        public bool IsConfirmed { get; set; } = false; // Par défaut, le panier n'est pas confirmé


        // Relation avec PaymentOrder
        // Clé étrangère pour lier le ShoppingCart au PaymentOrder
        public int? PaymentOrderId { get; set; }
        // Propriété de navigation vers le PaymentOrder
        public virtual PaymentOrder PaymentOrder { get; set; }


        public virtual ICollection<Product> Products { get; } = new List<Product>();

    }
}
