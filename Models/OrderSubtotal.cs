﻿using System;
using System.Collections.Generic;

namespace Lab_10___Call_the_database.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
