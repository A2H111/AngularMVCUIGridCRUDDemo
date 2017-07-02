using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AngularMVCUIGrid.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string CompanyName { get; set; }
    }

    public class NorthwindDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}