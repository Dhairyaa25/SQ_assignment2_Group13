using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yuvraj_FE_Part1.PlantNurseryInventory.Models;
using Yuvraj_FE_Part1.PlantNurseryInventory.Services;

namespace PlantNurseryInventory.Pages
{
    public class EditModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        [BindProperty]
        public InventoryItem InventoryItem { get; set; }

        public EditModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                InventoryItem = _inventoryService.LoadInventory().FirstOrDefault(i => i.Id == id);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _inventoryService.SaveInventoryItem(InventoryItem);
            return RedirectToPage("List");
        }
    }
}
