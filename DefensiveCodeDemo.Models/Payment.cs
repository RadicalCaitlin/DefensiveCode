using System;
using System.Collections.Generic;
using System.Text;

namespace DefensiveCodeDemo.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public decimal Total { get; set; }
    }
}
