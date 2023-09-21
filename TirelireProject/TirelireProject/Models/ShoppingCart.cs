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

        [Required(ErrorMessage = "Le produit ajouté au panier est requis.")]
        [Display(Name = "Produit ajouté au panier")]
        public int CartProductAdded { get; set; }

        [Required(ErrorMessage = "Le produit annulé du panier est requis.")]
        [Display(Name = "Produit annulé du panier")]
        public int CartProductCancelled { get; set; }

        [Required(ErrorMessage = "Les détails du panier sont requis.")]
        [Display(Name = "Détails du panier")]
        public int CartDetails { get; set; }

        [Required(ErrorMessage = "L'expédition du panier est requise.")]
        [Display(Name = "Expédition du panier")]
        public int CartShipping { get; set; }

        [Display(Name = "Prix du panier")]
        public int CartPriceHT { get; set; }


        public virtual ICollection<Product> Products { get; } = new List<Product>();
        public virtual ICollection<CartItem> CartItems { get; } = new CartItem[0];
    }
}
