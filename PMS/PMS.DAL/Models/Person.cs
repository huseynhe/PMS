using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.DAL.Models
{
    public class Person
    {
  
        public int Id { get; set; }
        public int PersonNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EnterDate { get; set; }
        public string Address { get; set; }
        public float SalaryRate { get; set; }
        public int TotalWorkTime { get; set; }


    }
}
