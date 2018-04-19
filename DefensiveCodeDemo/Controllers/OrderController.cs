using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DefensiveCodeDemo.Contracts;
using DefensiveCodeDemo.Contracts.Repositories;
using DefensiveCodeDemo.Models;
using DefensiveCodeDemo.Models.OrderViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DefensiveCodeDemo.Controllers
{
    public class OrderController : Controller
    {

        private readonly DefensiveCodeContext _dbContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(
            DefensiveCodeContext dbContext,
            ICustomerRepository customerRepository,
            IInventoryRepository inventoryRepository,
            IOrderRepository orderRepository
            )
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
            _inventoryRepository = inventoryRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index(string error)
        {
            var model = new CustomerOrderFormViewModel
            {
                InventoryList = await _inventoryRepository.GetInventoryAsync(),
                OrderInventory = new List<OrderInventory>(),
                Error = error
            };

            return View(model);
        }

        [HttpPost]
        [Route("/Home/HandleCustomerOrderSubmission")]
        public async Task<IActionResult> HandleCustomerOrderSubmission(CustomerOrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Order", new { error = "You done goofed!" });
            }

            var customerForOrder = await _dbContext.Customer.SingleOrDefaultAsync(c => c.Email == model.Email);

            var newOrder = new Order
            {
                CustomerId = customerForOrder.Id,
                DateCreatedUTC = DateTime.UtcNow
            };

            _dbContext.Order.Add(newOrder);
            await _dbContext.SaveChangesAsync();

            decimal orderTotal = 0;

            foreach (var item in model.OrderInventory)
            {
                var inventoryItem = await _dbContext.Inventory.SingleOrDefaultAsync(i => i.Id == item.InventoryId);
                var enoughInventoryAvailable = inventoryItem.AmountAvailable >= item.Quantity;

                if (enoughInventoryAvailable)
                {
                    item.OrderId = newOrder.Id;

                    _dbContext.OrderInventory.Add(item);
                    await _dbContext.SaveChangesAsync();

                    orderTotal += (inventoryItem.PricePerUnit * item.Quantity);

                    var newAvailableAmount = inventoryItem.AmountAvailable - item.Quantity;

                    inventoryItem.AmountAvailable = newAvailableAmount;

                    _dbContext.Inventory.Update(inventoryItem);
                    await _dbContext.SaveChangesAsync();
                }
            }

            var newPayment = new Payment
            {
                CustomerId = customerForOrder.Id,
                OrderId = newOrder.Id,
                Total = orderTotal
            };

            _dbContext.Payment.Add(newPayment);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("/Home/HandleCustomerOrderSubmissionRefactored")]
        public async Task<IActionResult> HandleCustomerOrderSubmissionRefactored(CustomerOrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Order", new { error = "You done goofed!" });
            }

            var customer = GetCustomerForOrderAsync(model);

            var order = await PrepareOrderForCustomer(customer.Id);
        }

        private async Task<Customer> GetCustomerForOrderAsync(CustomerOrderFormViewModel model)
        {
            var customerResult = await _dbContext.Customer.SingleOrDefaultAsync(c => c.Email == model.Email);

            if (customerResult != null)
                return customerResult;

            var newCustomer = model.CreateCustomerObject();

            return await _customerRepository.CreateCustomerAsync(newCustomer);
        }

        private Order GetOrderObject(int customerId)
        {
            var newOrder = new Order
            {
                CustomerId = customerId,
                DateCreatedUTC = DateTime.UtcNow
            };

            return newOrder;
        }

        private async Task<Order> PrepareOrderForCustomer(int customerId)
        {
            var orderObject = GetOrderObject(customerId);

            var newOrder = await _orderRepository.CreateOrderAsync(orderObject);

            return newOrder;
        }
    }
}