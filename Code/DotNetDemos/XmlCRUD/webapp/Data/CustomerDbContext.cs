#region db_context
using Microsoft.EntityFrameworkCore;

namespace webapp.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext (DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<webapp.Models.Customer> Customer => Set<webapp.Models.Customer>();
    }
}
#endregion