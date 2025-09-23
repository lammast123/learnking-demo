using LearnKing.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnKing.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}