using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManager.Model;

namespace TaskManager.applicationDbContext
{
    public class applicationDbContext:IdentityDbContext<appUser>
    {
        public applicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

            
        }
        public DbSet<appUser> Users { get; set; }
    }
}
