
using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManagement.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Staff> Staffs { get; set; }
}
