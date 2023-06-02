using codefirst_net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace codefirst_net
{
    public class InvoiceSystemContext : DbContext
    {
        public InvoiceSystemContext() : base("name = MyContextDB") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Detail> Details { get; set; }
    }
}