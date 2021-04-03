using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(45)]
        [Display(Name = "Products Name")]
        public string ProductsName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        [Display(Name = "Buying Price")]
        public decimal BuyingPrice { get; set; }
        [Display(Name = "Sales Price")]
        public decimal SalesPrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }
        public string Explanation { get; set; }
        public int Installment { get; set; }
        public bool NewArrivals { get; set; }
        public bool BestSellers { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}