using Microsoft.EntityFrameworkCore;
using Redactor.Demo.Models;

namespace Redactor.Demo;

internal class DemoDbContext(DbContextOptions options)
    : DbContext(options)
{
    public DbSet<User>? Users { get; set; }
}