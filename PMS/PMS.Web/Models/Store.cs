using System;
using System.Collections.Generic;

#nullable disable

namespace PMS.Web.Models
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            ProductCategories = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StoreType { get; set; }

        public virtual Merchant Merchant { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
