using Microsoft.EntityFrameworkCore;

namespace myapp.Models
{
    public class userContext : DbContext
    {
        public userContext(DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public DbSet<usermaster> usermasters { get; set; }
    }
}
