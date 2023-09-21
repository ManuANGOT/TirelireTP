using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TirelireProject.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du produit est requis.")]
        [StringLength(50, ErrorMessage = "Le nom du produit ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Nom du produit")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "La description du produit est requise.")]
        [StringLength(1000, ErrorMessage = "La description du produit ne peut pas dépasser 1000 caractères.")]
        [Display(Name = "Description du produit")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "La hauteur du produit est requise.")]
        [Display(Name = "Hauteur du produit")]
        public string? ProductHeight { get; set; }

        [Required(ErrorMessage = "La largeur du produit est requise.")]
        [Display(Name = "Largeur du produit")]
        public string? ProductWidth { get; set; }

        [Required(ErrorMessage = "Le poids du produit est requis.")]
        [Display(Name = "Poids du produit")]
        public string? ProductWeight { get; set; }

        [Required(ErrorMessage = "La longueur du produit est requise.")]
        [Display(Name = "Longueur du produit")]
        public string? ProductLength { get; set; }

        [Required(ErrorMessage = "La couleur du produit est requise.")]
        [StringLength(50, ErrorMessage = "La couleur du produit ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Couleur du produit")]
        public string? ProductColor { get; set; }

        [Required(ErrorMessage = "La capacité du produit est requise.")]
        [StringLength(50, ErrorMessage = "La capacité du produit ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Capacité du produit")]
        public string? ProductCapacity { get; set; }

        [Required(ErrorMessage = "Le fabricant du produit est requis.")]
        [StringLength(50, ErrorMessage = "Le fabricant du produit ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Fabricant du produit")]
        public string? ProductMaker { get; set; }

        [Required(ErrorMessage = "L'image du produit est requise.")]
        [Display(Name = "Image du produit")]
        public byte[]? ProductImage { get; set; }

        [Required(ErrorMessage = "Le prix du produit est requis.")]
        [Display(Name = "Prix du produit")]
        public float ProductPrice { get; set; }

        public virtual ICollection<Product> Products { get; }=new List<Product>();
        public int Quantity { get; internal set; }
    }
}
