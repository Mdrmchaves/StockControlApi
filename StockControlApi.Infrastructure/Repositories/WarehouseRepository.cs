using Microsoft.EntityFrameworkCore;
using StockControlApi.Core.Entities;
using StockControlApi.Core.Interfaces;
using StockControlApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlApi.Infrastructure.Repositories
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(StockContext context) : base(context) { }

        public async Task<IEnumerable<Warehouse>> GetFullWareHouses()
        {
            return await _context.Warehouses
                            .Where(w => w.Capacity == 0)
                            .ToListAsync();
        }
    }
}
