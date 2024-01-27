using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Data;


public class DataContext : DbContext
{
    // constructor
    public DataContext(DbContextOptions options) : base(options)
    {
    }

// User -- name of the table created in DB for AppUser
    public DbSet<AppUser> Users{ get; set; }
}
