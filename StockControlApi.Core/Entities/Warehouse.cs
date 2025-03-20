using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlApi.Core.Entities
{
    public class Warehouse
    {
        public int Id { get; private set; }
        public string WarehouseName { get; private set; }
        public string WarehouseDescription { get; private set; }
        public string WarehouseLocation { get; private set; }
        public int? Capacity { get; private set; }
        public bool IsActive { get; private set; }

        private Warehouse() { }

        public Warehouse(string warehouseName, string warehouseDescription, string warehouseLocation, int? capacity, bool isActive)
        {
            WarehouseName = string.IsNullOrWhiteSpace(warehouseName) ? throw new ArgumentException("Warehouse name is required.") : warehouseName;
            WarehouseDescription = warehouseDescription;
            WarehouseLocation = string.IsNullOrWhiteSpace(warehouseLocation) ? throw new ArgumentException("Warehouse Location is required") : warehouseLocation;
            Capacity = capacity;
            IsActive = isActive;
        }
    }
}
