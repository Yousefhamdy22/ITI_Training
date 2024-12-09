using Microsoft.EntityFrameworkCore;
using PearlySoft.Models;

namespace PearlySoft.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
