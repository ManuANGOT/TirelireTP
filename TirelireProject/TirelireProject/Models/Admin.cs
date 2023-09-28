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
    public class Admin
    {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
            [Required(ErrorMessage = "Le nom de l'Admin est requis.")]
            [StringLength(50, ErrorMessage = "Le nom l'Admin ne peut pas dépasser 50 caractères.")]
            [Display(Name = "Nom")]
            public string? AdminName { get; set; }

           
            [Required(ErrorMessage = "L'email l'Admin est requis.")]
            [StringLength(50, ErrorMessage = "Le nom l'Admin ne peut pas dépasser 50 caractères.")]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Le mot de passe l'Admin est requis.")]
            [StringLength(50, ErrorMessage = "Le nom l'Admin ne peut pas dépasser 50 caractères.")]
            [Display(Name = "Password")]
            public string? Password { get; set; }

        public virtual ICollection<Admin> Admins { get; } = new List<Admin>();
    }
    
}