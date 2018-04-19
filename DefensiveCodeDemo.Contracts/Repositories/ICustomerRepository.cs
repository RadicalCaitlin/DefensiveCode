using DefensiveCodeDemo.Models;
using System;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
