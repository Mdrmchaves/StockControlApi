using StockControlApi.Core.Entities;
using StockControlApi.Core.Interfaces;
using StockControlApi.Application.Dtos;
using StockControlApi.Application.Contracts;

namespace StockControlApi.Application.Services;

public class StockService : IStockService
{
    private readonly IItemRepository _itemRepository;
    private readonly IOrderRepository _orderRepository;

    public StockService(IItemRepository itemRepository, IOrderRepository orderRepository)
    {
        _itemRepository = itemRepository;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        var items = await _itemRepository.GetAllAsync();
        return items.Select(i => new ItemDto
        {
            Id = i.Id,
            Name = i.Name,
            Quantity = i.Quantity,
            MinQuantity = i.MinQuantity,
            Category = i.Category,
            WarehouseId = i.WarehouseId,
            WarehouseName = i.Warehouse?.WarehouseName,
            FindCode = i.FindCode
        });
    }

    public async Task<IEnumerable<ItemDto>> GetLowStockItemsAsync()
    {
        var items = await _itemRepository.GetLowStockItemsAsync();
        return items.Select(i => new ItemDto
        {
            Id = i.Id,
            Name = i.Name,
            Quantity = i.Quantity,
            MinQuantity = i.MinQuantity,
            Category = i.Category,
            WarehouseId = i.WarehouseId,
            WarehouseName = i.Warehouse?.WarehouseName,
            FindCode = i.FindCode
        });
    }

    public async Task<ItemDto> AddItemAsync(ItemDto itemDto)
    {
        var item = new Item(itemDto.Name, itemDto.Quantity, itemDto.MinQuantity, itemDto.Category, itemDto.WarehouseId, itemDto.FindCode);
        await _itemRepository.AddAsync(item);
        return new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Quantity = item.Quantity,
            MinQuantity = item.MinQuantity,
            Category = item.Category,
            WarehouseId = item.WarehouseId,
            FindCode = item.FindCode
        };
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            ItemId = o.ItemId,
            ItemName = o.Item?.Name,
            QuantityOrdered = o.QuantityOrdered,
            OrderDate = o.OrderDate,
            OrderType = o.OrderType,
            OriginWarehouseId = o.OriginWarehouseId,
            OriginWarehouseName = o.OriginWarehouse?.WarehouseName,
            DestinationWarehouseId = o.DestinationWarehouseId,
            DestinationWarehouseName = o.DestinationWarehouse?.WarehouseName
        });
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByTypeAsync(string orderType)
    {
        var orders = await _orderRepository.GetOrdersByTypeAsync(orderType);
        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            ItemId = o.ItemId,
            ItemName = o.Item?.Name,
            QuantityOrdered = o.QuantityOrdered,
            OrderDate = o.OrderDate,
            OrderType = o.OrderType,
            OriginWarehouseId = o.OriginWarehouseId,
            OriginWarehouseName = o.OriginWarehouse?.WarehouseName,
            DestinationWarehouseId = o.DestinationWarehouseId,
            DestinationWarehouseName = o.DestinationWarehouse?.WarehouseName
        });
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByItemIdAsync(int itemId)
    {
        var orders = await _orderRepository.GetOrdersByItemIdAsync(itemId);
        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            ItemId = o.ItemId,
            ItemName = o.Item?.Name,
            QuantityOrdered = o.QuantityOrdered,
            OrderDate = o.OrderDate,
            OrderType = o.OrderType,
            OriginWarehouseId = o.OriginWarehouseId,
            OriginWarehouseName = o.OriginWarehouse?.WarehouseName,
            DestinationWarehouseId = o.DestinationWarehouseId,
            DestinationWarehouseName = o.DestinationWarehouse?.WarehouseName
        });
    }

    public async Task<OrderDto> AddOrderAsync(OrderDto orderDto)
    {
        var order = new Order(orderDto.ItemId, orderDto.QuantityOrdered, orderDto.OrderDate, orderDto.OrderType, orderDto.OriginWarehouseId, orderDto.DestinationWarehouseId);
        await _orderRepository.AddAsync(order);
        return new OrderDto
        {
            Id = order.Id,
            ItemId = order.ItemId,
            QuantityOrdered = order.QuantityOrdered,
            OrderDate = order.OrderDate,
            OrderType = order.OrderType,
            OriginWarehouseId = order.OriginWarehouseId,
            DestinationWarehouseId = order.DestinationWarehouseId
        };
    }
}