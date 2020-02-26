using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeneralStore.Models
{
    public class ApplicationDBContext:DbContext
    {
        //ctor shortcut
        public ApplicationDBContext() : base("DefaultConnection") { }
            //*DefaultConnection found in Web.config*//{ }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}