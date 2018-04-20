using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefensiveCodeDemo.Models
{
    public class DefensiveCodeContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderInventory> OrderInventory { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DefensiveCodeContext(DbContextOptions<DefensiveCodeContext> options) : base(options)
        {

        }

        public DefensiveCodeContext()
        {
        }
    }
}
