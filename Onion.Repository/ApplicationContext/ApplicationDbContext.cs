using Microsoft.EntityFrameworkCore;
using Onion.Data.Access;
using Onion.Data.Account;

namespace Onion.Repository.ApplicationContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
