using System;
using System.Collections.Generic;
using System.Text;

namespace DefensiveCodeDemo.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PricePerUnit { get; set; }

        public int AmountAvailable { get; set; }
    }
}
