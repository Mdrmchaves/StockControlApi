using Microsoft.AspNetCore.Mvc;
using StockControlApi.Application.Contracts;
using StockControlApi.Application.Dtos;

namespace StockControlApi.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
    {
        var items = await _stockService.GetItemsAsync();
        return Ok(items);
    }

    [HttpGet("low-stock")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetLowStockItems()
    {
        var items = await _stockService.GetLowStockItemsAsync();
        return Ok(items);
    }

    [HttpGet("orders-report")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersReport()
    {
        var orders = await _stockService.GetOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("orders-report/by-type/{type}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByType(string type)
    {
        var orders = await _stockService.GetOrdersByTypeAsync(type);
        return Ok(orders);
    }

    [HttpGet("orders-report/by-item/{itemId}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByItemId(int itemId)
    {
        var orders = await _stockService.GetOrdersByItemIdAsync(itemId);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> AddItem([FromBody] ItemDto itemDto)
    {
        var item = await _stockService.AddItemAsync(itemDto);
        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }

    [HttpPost("order")]
    public async Task<ActionResult<OrderDto>> AddOrder([FromBody] OrderDto orderDto)
    {
        var order = await _stockService.AddOrderAsync(orderDto);
        return CreatedAtAction(nameof(GetOrdersReport), new { id = order.Id }, order);
    }
}