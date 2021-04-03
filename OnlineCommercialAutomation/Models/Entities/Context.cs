using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineCommercialAutomation.Models.Entities
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins  { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Current> Currents  { get; set; }
        public DbSet<Department> Departments  { get; set; }
        public DbSet<Expense> Expenses  { get; set; }
        public DbSet<Invoice> Invoices  { get; set; }
        public DbSet<InvoiceContent> InvoiceContents  { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<SalesMovement> SalesMovements  { get; set; }
        public DbSet<Staff> Staffs  { get; set; } 
        public DbSet<Details> Detailss  { get; set; }
        public DbSet<ToDoList> ToDoLists  { get; set; }
        public DbSet<Cargo> Cargos  { get; set; }
        public DbSet<CargoTracking> CargoTrackings  { get; set; }
        public DbSet<Contact> Contacts  { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
    }
}