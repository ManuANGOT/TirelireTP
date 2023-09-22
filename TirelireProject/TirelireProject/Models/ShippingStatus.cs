using System.ComponentModel.DataAnnotations;

namespace TirelireProject.Models
{
           public enum OrderShippingStatus
        {
            Prepared,
            Shipped,
            Delivered
        }

        public class ShippingStatus
        {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le statut de livraison est requis.")]
        [Display(Name = "Statut de livraison")]
        public OrderShippingStatus Status { get; set; }

        // Relations
        public int? ShoppingCartId { get; set; } // Identifiant du panier associé
        public virtual ShoppingCart? ShoppingCart { get; set; } // Relation avec le panier

        public int? PaymentOrderId { get; set; } // Identifiant de la commande de paiement associée
        public virtual PaymentOrder? PaymentOrder { get; set; } // Relation avec la commande de paiement
    }
    
}
