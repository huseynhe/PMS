using System;
using System.Collections.Generic;

#nullable disable

namespace PMS.Web.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Merchant Merchant { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
