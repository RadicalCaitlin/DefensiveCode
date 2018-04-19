using DefensiveCodeDemo.Contracts.Repositories;
using DefensiveCodeDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DefensiveCodeContext _dbContext;

        public PaymentRepository(DefensiveCodeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _dbContext.Payment.ToListAsync();
        }

    }
}
