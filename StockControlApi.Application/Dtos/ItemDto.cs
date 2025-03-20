namespace StockControlApi.Application.Dtos;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int MinQuantity { get; set; }
    public string Category { get; set; }
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; }
    public string FindCode { get; set; }
}