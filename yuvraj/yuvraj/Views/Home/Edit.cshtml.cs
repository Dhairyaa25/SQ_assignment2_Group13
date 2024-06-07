using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using yuvraj.Services;
using yuvraj.Models;

namespace yuvraj.Pages
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
                InventoryItem = _inventoryService.LoadInventory().FirstOrDefault(i => 1 == id);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _inventoryService.SaveInventory([InventoryItem]);
            return RedirectToPage("List");
        }
    }
}
