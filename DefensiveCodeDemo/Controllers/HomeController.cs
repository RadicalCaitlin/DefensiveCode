using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DefensiveCodeDemo.Models;
using DefensiveCodeDemo.Contracts.Repositories;
using DefensiveCodeDemo.ViewModels.HomeViewModels;

namespace DefensiveCodeDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DefensiveCodeContext _dbContext;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPaymentRepository _paymentRepository;

        public HomeController(
            DefensiveCodeContext dbContext,
            IInventoryRepository inventoryRepository,
            IPaymentRepository paymentRepository
            )
        {
            _dbContext = dbContext;
            _inventoryRepository = inventoryRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Index(string error)
        {
            var model = new HomeViewModel
            {
                Payments = await _paymentRepository.GetPaymentsAsync()
            };

            return View(model);
        }
    }
}
