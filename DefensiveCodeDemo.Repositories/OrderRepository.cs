using DefensiveCodeDemo.Contracts.Repositories;
using DefensiveCodeDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DefensiveCodeContext _dbContext;

        public OrderRepository(DefensiveCodeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderInventory> AddOrderInventoryAsync(OrderInventory orderInventory)
        {
            _dbContext.OrderInventory.Add(orderInventory);
            await _dbContext.SaveChangesAsync();

            return orderInventory;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _dbContext.Order.Add(order);
            await _dbContext.SaveChangesAsync();

            return order;
           
        }
    }
}
