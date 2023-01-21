using System;
using System.Collections.Generic;

#nullable disable

namespace PMS.Web.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string WorkEmail { get; set; }
        public string Phone { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
