﻿using DefensiveCodeDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderInventory> AddOrderInventoryAsync(OrderInventory orderInventory);

        Task<Order> CreateOrderAsync(Order order);
    }
}
