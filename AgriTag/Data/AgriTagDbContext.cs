using AgriTag.Common.Configuration;
using AgriTag.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AgriTag.Data
{
    public class AgriTagDbContext : DbContext
    {
        public AgriTagDbContext() { }

        public AgriTagDbContext(DbContextOptions<AgriTagDbContext> options, IOptions<DataRepositoryConfiguration> dataRepoConfig) : base(options) 
        {
            Database.SetConnectionString(dataRepoConfig.Value.ConnectionString);
        }

        public DbSet<ProduceType> ProduceTypes { get; set; }
    }
}
