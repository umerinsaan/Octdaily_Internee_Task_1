using Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Backend.Data
{
    public class CrudAppDbContext : DbContext
    {
        public CrudAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
