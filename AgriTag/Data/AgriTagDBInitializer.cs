using Microsoft.EntityFrameworkCore;

namespace AgriTag.Data
{
    public static class AgriTagDBInitializer
    {
        public static void Initialize(AgriTagDbContext context) 
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
