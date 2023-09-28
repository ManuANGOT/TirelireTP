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
    public class Mod
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du Modérateur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom du Modérateur ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Nom")]
        public string? ModName { get; set; }


        [Required(ErrorMessage = "L'email du Modérateur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom du Modérateur ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe du Modérateur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom du Modérateur ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        public virtual ICollection<Mod> Mods { get; } = new List<Mod>();

    }
}