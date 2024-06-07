using Microsoft.AspNetCore.Mvc;

namespace Yuvraj_FE_Part1
{
    using PlantNurseryInventory.Models;
    using System.Text.Json;

    namespace PlantNurseryInventory.Services
    {
        public class InventoryService
        {
            private string _filePath = "wwwroot/inventory.json";

            public List<InventoryItem> LoadInventory()
            {
                try
                {
                    string json = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<InventoryItem>>(json) ?? new List<InventoryItem>();
                }
                catch
                {
                    // Ideally, log this error
                    return new List<InventoryItem>();
                }
            }

            public void SaveInventory(List<InventoryItem> items)
            {
                try
                {
                    string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(_filePath, json);
                }
                catch
                {
                    // Ideally, log this error
                }
            }

            public void SaveInventoryItem(InventoryItem item)
            {
                var items = LoadInventory();
                var existingItem = items.FirstOrDefault(x => x.ItemName == item.ItemName);
                if (existingItem == null)
                {
                    items.Add(item);
                }
                else
                {
                    existingItem.QuantityInStock = item.QuantityInStock;
                    existingItem.PricePerUnit = item.PricePerUnit;
                }
                SaveInventory(items);
            }
        }
    }

}
