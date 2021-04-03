using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Explanation { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}