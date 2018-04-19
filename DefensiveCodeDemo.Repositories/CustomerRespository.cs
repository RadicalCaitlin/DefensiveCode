using DefensiveCodeDemo.Contracts;
using DefensiveCodeDemo.Models;
using System;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefensiveCodeContext _dbContext;

        public CustomerRepository(DefensiveCodeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

    }
}
