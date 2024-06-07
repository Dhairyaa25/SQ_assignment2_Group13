using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Load user credentials from JSON file
        var usersJson = await System.IO.File.ReadAllTextAsync("Data/users.json");
        var users = JsonSerializer.Deserialize<List<User>>(usersJson);

        // Validate user credentials
        var user = users.Find(u => u.Username == Username && u.Password == Password);
        if (user == null)
            return RedirectToPage("/Error");

        // Redirect to homepage upon successful login
        return RedirectToPage("/Index");
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}
