﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PMS.Web.Models
{
    public partial class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
