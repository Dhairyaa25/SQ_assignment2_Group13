using Microsoft.AspNetCore.Mvc.RazorPages;
    using yuvraj.Models;
    using yuvraj.PlantNurseryInventory.Services;

    namespace PlantNurseryInventory.Pages
    {
        public class ListModel : PageModel
        {
            private readonly InventoryService _inventoryService;

            public List<InventoryItem> InventoryItems { get; set; }

            public ListModel(InventoryService inventoryService)
            {
                _inventoryService = inventoryService;
            }

            public void OnGet()
            {
                InventoryItems = _inventoryService.LoadInventory();
            }
        }
    }