using System;
using System.Collections.Generic;

#nullable disable

namespace PMS.Web.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            ProductCategories = new HashSet<ProductCategory>();
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
