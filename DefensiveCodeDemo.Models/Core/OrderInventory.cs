using System;
using System.Collections.Generic;
using System.Text;

namespace DefensiveCodeDemo.Models
{
    public class OrderInventory
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int InventoryId { get; set; }

        public int Quantity { get; set; }
    }
}
