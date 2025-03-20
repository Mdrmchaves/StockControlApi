using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlApi.Core.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int ItemId { get; private set; }
        public int QuantityOrdered { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderType { get; private set; }
        public int? OriginWarehouseId { get; private set; }
        public int? DestinationWarehouseId { get; private set; }
        public Warehouse OriginWarehouse { get; set; }
        public Warehouse DestinationWarehouse { get; set; }
        public Item Item { get; set; } // Propriedade de navegação para o Item

        private Order() { }

        public Order(int itemId, int quantityOrdered, DateTime orderDate, string orderType, int? originWarehouseId, int? destinationWarehouseId)
        {
            ItemId = itemId <= 0 ? throw new ArgumentException("Valid ItemId is required.") : itemId;
            QuantityOrdered = quantityOrdered <= 0 ? throw new ArgumentException("Quantity ordered must be greater than zero.") : quantityOrdered;
            OrderDate = orderDate == default ? throw new ArgumentException("Order date is required.") : orderDate;
            OrderType = string.IsNullOrWhiteSpace(orderType) || !new[] { "Transfer", "Buy", "Sell" }.Contains(orderType)
                ? throw new ArgumentException("Order type must be Transfer, Buy, or Sell.") : orderType;
            
            OriginWarehouseId = orderType == "Sell" && !originWarehouseId.HasValue
                ? throw new ArgumentException("Sell orders must specify an OriginWarehouseId.") : originWarehouseId;
            
            DestinationWarehouseId = orderType == "Buy" && !destinationWarehouseId.HasValue
                ? throw new ArgumentException("Buy orders must specify a DestinationWarehouseId.") : destinationWarehouseId;
            
            if (orderType == "Transfer" && (!originWarehouseId.HasValue || !destinationWarehouseId.HasValue))
            {
                throw new ArgumentException("Transfer orders must specify both OriginWarehouseId and DestinationWarehouseId.");
            }
        }
    }
}
