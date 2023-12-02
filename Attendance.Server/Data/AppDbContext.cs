using Attendance.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}