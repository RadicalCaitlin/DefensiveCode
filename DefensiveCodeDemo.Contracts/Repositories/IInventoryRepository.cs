using DefensiveCodeDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Contracts.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoryAsync();

        Task<Inventory> UpdateInventoryAsync(Inventory inventory);
    }
}
