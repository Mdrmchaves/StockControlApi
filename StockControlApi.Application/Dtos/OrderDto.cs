namespace StockControlApi.Application.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public int QuantityOrdered { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderType { get; set; }
    public int? OriginWarehouseId { get; set; }
    public string OriginWarehouseName { get; set; }
    public int? DestinationWarehouseId { get; set; }
    public string DestinationWarehouseName { get; set; }
}