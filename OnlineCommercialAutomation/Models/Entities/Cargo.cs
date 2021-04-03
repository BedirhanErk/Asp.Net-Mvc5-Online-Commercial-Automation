using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Cargo
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "You can type up to 10 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "You can type up to 20 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Staff { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "You can type up to 20 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
    }
}