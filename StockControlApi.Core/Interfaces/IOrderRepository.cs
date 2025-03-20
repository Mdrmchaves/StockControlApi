using StockControlApi.Core.Entities;

namespace StockControlApi.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByTypeAsync(string orderType);
        Task<IEnumerable<Order>> GetOrdersByItemIdAsync(int itemId);
    }
}
