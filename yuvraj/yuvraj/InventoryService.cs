using yuvraj.Models;
using System.Text.Json;

namespace yuvraj.Services
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
            catch (Exception)
            {
                // Handle exceptions or create a logging mechanism
                return new List<InventoryItem>();
            }
        }

        public void SaveInventory(List<InventoryItem> items)
        {
            try
            {
                string json = JsonSerializer.Serialize(items);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception)
            {
                // Handle exceptions or create a logging mechanism
            }
        }
    }
}
