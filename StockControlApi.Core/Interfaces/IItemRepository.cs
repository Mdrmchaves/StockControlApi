using StockControlApi.Core.Entities;


namespace StockControlApi.Core.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetLowStockItemsAsync();
    }
}
