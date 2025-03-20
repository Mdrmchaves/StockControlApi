using StockControlApi.Application.Dtos;

namespace StockControlApi.Application.Contracts;

public interface IStockService
{
    Task<IEnumerable<ItemDto>> GetItemsAsync();
    Task<IEnumerable<ItemDto>> GetLowStockItemsAsync();
    Task<ItemDto> AddItemAsync(ItemDto itemDto);
    Task<IEnumerable<OrderDto>> GetOrdersAsync();
    Task<IEnumerable<OrderDto>> GetOrdersByTypeAsync(string orderType);

    Task<IEnumerable<OrderDto>> GetOrdersByItemIdAsync(int itemId);
    Task<OrderDto> AddOrderAsync(OrderDto orderDto);
}