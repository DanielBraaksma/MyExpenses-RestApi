using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<Models.ExpenseTracker> Expenses { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) 
            :base(options)
        {
        
        }
    }
}
