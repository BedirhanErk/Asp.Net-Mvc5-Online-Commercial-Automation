using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can type up to 30 characters.")]
        [Display(Name ="Category Name")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public bool OnHome { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}