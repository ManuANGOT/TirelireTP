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
            public OrderShippingStatus Status { get; set; }

            // Relations
            public int OrderId { get; set; } // Identifiant de la commande associée
            public virtual Order Order { get; set; } // Relation avec la commande
        }
    
}
