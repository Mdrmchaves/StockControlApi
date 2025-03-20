using StockControlApi.Core.Entities;
using StockControlApi.Core.Interfaces;
using StockControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace StockControlApi.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(StockContext context) : base(context) { }

    public async Task<IEnumerable<Order>> GetOrdersByTypeAsync(string orderType)
    {
        return await _context.Orders
            .Include(o => o.Item)
            .Include(o => o.OriginWarehouse)
            .Include(o => o.DestinationWarehouse)
            .Where(o => o.OrderType.ToLower() == orderType.ToLower())
            .OrderBy(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByItemIdAsync(int itemId)
    {
        return await _context.Orders
            .Include(o => o.Item)
            .Include(o => o.OriginWarehouse)
            .Include(o => o.DestinationWarehouse)
            .Where(o => o.ItemId == itemId)
            .OrderBy(o => o.OrderDate)
            .ToListAsync();
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Item)
            .Include(o => o.OriginWarehouse)
            .Include(o => o.DestinationWarehouse)
            .OrderBy(o => o.OrderDate)
            .ToListAsync();
    }
}