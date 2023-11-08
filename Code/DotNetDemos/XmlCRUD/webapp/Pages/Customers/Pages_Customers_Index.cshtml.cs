using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Pages.Customers
{
    #region snippet
    public class Pages_Customers_IndexModel : PageModel
    {
        private readonly Data.CustomerDbContext _context;
        public Pages_Customers_IndexModel(Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IList<Customer>? Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customer.ToListAsync();
        }

        #region snippet2
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _context.Customer.FirstAsync(id);

            if (contact != null)
            {
                _context.Customer.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
        #endregion
    }
    #endregion
}