using Employee_Angular_WebAPI_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_Angular_WebAPI_2.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
  }
}
