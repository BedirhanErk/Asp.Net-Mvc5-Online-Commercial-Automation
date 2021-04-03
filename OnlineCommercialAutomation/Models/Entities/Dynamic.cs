using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Dynamic
    {
        public IEnumerable<Invoice> value1 { get; set; }
        public IEnumerable<InvoiceContent> value2 { get; set; }
    }
}