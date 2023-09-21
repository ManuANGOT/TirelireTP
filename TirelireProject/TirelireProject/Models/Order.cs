namespace TirelireProject.Models
{
    public class Order
    {        public int Id { get; set; }
        public int CustomerId { get; set; } // Identifiant du client qui a passé la commande
        public virtual Customer Customer { get; set; } // Relation avec le client
        public virtual ICollection<ShippingStatus> ShippingStatusHistory { get; set; }
    }
}
