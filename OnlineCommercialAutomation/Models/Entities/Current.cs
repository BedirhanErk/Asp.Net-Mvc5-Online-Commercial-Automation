using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Current
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "You can type up to 30 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        [Display(Name = "Currents Name")]
        public string CurrentsName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can type up to 30 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        [Display(Name = "Currents Surname")]
        public string CurrentsSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "You can type up to 30 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        [Display(Name = "Currents City")]
        public string CurrentsCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50,ErrorMessage = "You can type up to 50 characters.")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        [Display(Name = "Currents Mail")]
        public string CurrentsMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Password { get; set; }
        public string CurrentImage { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}