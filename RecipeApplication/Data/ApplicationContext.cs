using Microsoft.EntityFrameworkCore;

namespace RecipeApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
    }
}
