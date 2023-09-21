using TirelireProject.Models;

namespace TirelireProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Identifiant du produit associé
        public int Quantity { get; set; }

        // Autres informations spécifiques à l'élément du panier, ajoutez-les ici

        // Relations
        public virtual Product Product { get; set; } // Relation avec le produit
        public int ShoppingCartId { get; set; } // Identifiant du panier associé
        public virtual ShoppingCart ShoppingCart { get; set; } // Relation avec le panier
    }
}
