using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace WebAPI.Data

{
    public class AddDbContext : DbContext
    {
        public AddDbContext (DbContextOptions<AddDbContext> options)
            : base(options)
        {

        }
        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}
