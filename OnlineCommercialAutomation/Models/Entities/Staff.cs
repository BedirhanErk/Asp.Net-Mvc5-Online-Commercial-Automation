using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [Display(Name = "Staff Name")]
        public string StaffName { get; set; }
        [Column(TypeName = "Varchar")]
        [Display(Name = "Staff Surname")]
        public string StaffSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [Display(Name = "Staff Image")]
        public string StaffImage { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}