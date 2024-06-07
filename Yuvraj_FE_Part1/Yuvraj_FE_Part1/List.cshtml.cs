namespace Yuvraj_FE_Part1
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using PlantNurseryInventory.Models;
    using PlantNurseryInventory.Services;

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

}
