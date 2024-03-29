using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;

namespace webapp.Pages.Customers
{
    //#region <snippet_PageModel>
    public class Pages_Customers_CreateModel : PageModel
    {
        private readonly Data.CustomerDbContext _context;

        public Pages_Customers_CreateModel(Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // <snippet_OnPostAsync>
        [BindProperty]
        public Customer? Customer { get; set; }

        // OnPostAsync: runs on POST requests (when a user posts the form) 👇
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Customer != null) _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Pages_Customers_Index");
        }
        // </snippet_OnPostAsync>
    }
    //#endregion </snippet_PageModel>
}