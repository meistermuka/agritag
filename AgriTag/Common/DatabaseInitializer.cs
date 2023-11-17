using AgriTag.Data;

namespace AgriTag.Common
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var mappedContext = services.GetRequiredService<AgriTagDbContext>();
                    logger.LogInformation("Initializing database");
                    AgriTagDBInitializer.Initialize(mappedContext);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occured while initializing the database.");
                }
            }
        }
    }
}
