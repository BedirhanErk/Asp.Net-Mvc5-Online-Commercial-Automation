using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "You can type up to 6 characters.")]
        [Display(Name = "Invoice Sequence No")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string InvoiceSequenceNo { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1, ErrorMessage = "You can type up to 1 characters.")]
        [Display(Name = "Invoice Serial No")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string InvoiceSerialNo { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "You can type up to 100 characters.")]
        [Display(Name = "Tax Administration")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5, ErrorMessage = "You can type up to 5 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Hour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can type up to 30 characters.")]
        [Display(Name = "Delivering Person")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string DeliveringPerson { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can type up to 30 characters.")]
        [Display(Name = "Receiver Person")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string ReceiverPerson { get; set; }
        public decimal Total { get; set; }
        public ICollection<InvoiceContent> InvoiceContents { get; set; }
    }
}