using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Details
    {
        [Key]
        public int DetailsId { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        [Display(Name = "Products Name")]
        public string ProductsName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        [Display(Name = "Products Information")]
        public string ProductsInformation { get; set; }
    }
}