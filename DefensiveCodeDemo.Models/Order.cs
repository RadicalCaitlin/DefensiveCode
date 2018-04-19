using System;
using System.Collections.Generic;
using System.Text;

namespace DefensiveCodeDemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTimeOffset DateCreatedUTC { get; set; }
    }
}
