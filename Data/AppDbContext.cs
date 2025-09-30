using Microsoft.EntityFrameworkCore;
using LearnKing.Api.Models;

namespace LearnKing.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; } // giữ lại Task bạn đã có
    }
}
