using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class SalesMovement
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CurrentId { get; set; }
        public virtual Current Current { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public int Piece { get; set; }
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
    }
}