using DefensiveCodeDemo.Contracts.Repositories;
using DefensiveCodeDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DefensiveCodeContext _dbContext;

        public InventoryRepository(DefensiveCodeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Inventory>> GetInventoryAsync()
        {
            return await _dbContext.Inventory.ToListAsync();
        }
    }
}
