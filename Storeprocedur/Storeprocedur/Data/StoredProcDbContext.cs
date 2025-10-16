using Microsoft.EntityFrameworkCore;
using Storeprocedur.Models;

namespace Storeprocedur.Data
{
    public class StoredProcDbContext : DbContext
    {
        public StoredProcDbContext(DbContextOptions<StoredProcDbContext> options)
            : base(options) { }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Student> Students { get; set; }
    }
}
