using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles="SuperAdmin,Admin")]
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();            
        public ActionResult InvoiceList()
        {
            var values = c.Invoices.ToList();
            return View(values);
        }
        public ActionResult Dynamic()
        {
            Dynamic dync = new Dynamic();
            dync.value1 = c.Invoices.ToList();
            dync.value2 = c.InvoiceContents.ToList();
            return View(dync);
        }
        public ActionResult SaveInvoice(string InvoiceSerialNo,string InvoiceSequenceNo,DateTime Date,string TaxAdministration,string Hour,string DeliveringPerson,string ReceiverPerson,string Total,InvoiceContent[] contents)
        {
            Invoice f = new Invoice();
            f.InvoiceSerialNo = InvoiceSerialNo;
            f.InvoiceSequenceNo = InvoiceSequenceNo;
            f.Date = Date;
            f.TaxAdministration = TaxAdministration;
            f.Hour = Hour;
            f.DeliveringPerson = DeliveringPerson;
            f.ReceiverPerson = ReceiverPerson;
            f.Total = decimal.Parse(Total);

            c.Invoices.Add(f);

            foreach (var x in contents)
            {
                InvoiceContent ic = new InvoiceContent();
                ic.Explanation = x.Explanation;
                ic.UnitPrice = x.UnitPrice;
                ic.Quantity = x.Quantity;
                ic.InvoiceId = x.Id;
                ic.Amount = x.Amount;
                c.InvoiceContents.Add(ic);
            }

            c.SaveChanges();
            return Json("Transaction Successful",JsonRequestBehavior.AllowGet);
        }
    }
}