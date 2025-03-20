using StockControlApi.Core.Entities;
using StockControlApi.Core.Interfaces;
using StockControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace StockControlApi.Infrastructure.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(StockContext context) : base(context) { }

    public async Task<IEnumerable<Item>> GetLowStockItemsAsync()
    {
        return await _context.Items
            .Include(i => i.Warehouse)
            .Where(i => i.Quantity < i.MinQuantity)
            .ToListAsync();
    }

    public override async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _context.Items
            .Include(i => i.Warehouse)
            .ToListAsync();
    }
}