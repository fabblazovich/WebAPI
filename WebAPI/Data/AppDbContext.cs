using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}
