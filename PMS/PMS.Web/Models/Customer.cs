using System;
using System.Collections.Generic;

#nullable disable

namespace PMS.Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
