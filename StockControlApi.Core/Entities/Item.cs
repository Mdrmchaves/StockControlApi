using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlApi.Core.Entities
{
    public class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public int MinQuantity { get; private set; }
        public string Category { get; private set; }
        public int WarehouseId { get; private set; }
        public string FindCode { get; private set; }
        public Warehouse Warehouse { get; set; }

        private Item() { }

        public Item(string name, int quantity, int minQuantity, string category, int warehouseId, string findCode)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Item name is required.") : name;
            Quantity = quantity < 0 ? throw new ArgumentException("Quantity cannot be negative.") : quantity;
            MinQuantity = minQuantity < 0 ? throw new ArgumentException("MinQuantity cannot be negative.") : minQuantity;
            Category = category;
            WarehouseId = warehouseId <= 0 ? throw new ArgumentException("Valid WarehouseId is required.") : warehouseId;
            FindCode = string.IsNullOrWhiteSpace(findCode) ? throw new ArgumentException("FindCode is required.") : findCode;
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity < 0 ? throw new ArgumentException("Quantity cannot be negative.") : newQuantity;
        }
    }
}
