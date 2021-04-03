using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can type up to 30 characters.")]
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}