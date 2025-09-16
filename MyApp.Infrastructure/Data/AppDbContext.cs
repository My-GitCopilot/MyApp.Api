using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;

namespace MyApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> contextOptions) : DbContext(contextOptions)
    {
       public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
