using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Title { get; set; }

        [Column(TypeName = "bit")]        
        public bool Status { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Hour { get; set; }

    }
}