using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Receiver { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Content { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Date { get; set; }

        public bool Status { get; set; }
        public bool Starry { get; set; }
    }
}