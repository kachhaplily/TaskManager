using Microsoft.EntityFrameworkCore;

namespace TaskManager.applicationDbContext
{
    public class applicationDbContext:DbContext
    {
        public applicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
    }
}
