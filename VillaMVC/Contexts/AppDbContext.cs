using Microsoft.EntityFrameworkCore;
using VillaMVC.Models;

namespace VillaMVC.Contexts;

public class AppDbContext:DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
    {
        
    }

    public DbSet<Villa> Villa { get; set; }

}
