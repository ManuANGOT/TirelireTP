using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TirelireProject.Models
{
    public class PaymentOrder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La date de la commande de paiement est requise.")]
        [Display(Name = "Date de la commande de paiement")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Montant total TTC")]
        public decimal TotalAmountTTC { get; set; }


        // Relations avec le panier
        public int? ShoppingCartId { get; set; } // Identifiant du panier associé
        public virtual ShoppingCart? ShoppingCart { get; set; } // Relation avec le panier


        // Relation avec le suivi de l'expédition
        public virtual ICollection<ShippingStatus>? ShippingStatusHistory { get; set; }
    }
}
