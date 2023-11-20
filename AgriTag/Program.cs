using AgriTag.Common;
using AgriTag.Common.Configuration;
using AgriTag.Data;
using AgriTag.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets<Program>(true);

    builder.Host.UseSerilog((context, config) =>
    {
        config.ReadFrom.Configuration(context.Configuration);
    });


    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddSerilog(); // Add Serilog to the logging pipeline
    });
    // Add services to the container.

    builder.Services.AddScoped<IProduceTypeRepository, ProduceTypeRepository>();

    builder.Services.AddControllers(
        options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddNewtonsoftJson();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.Configure<DataRepositoryConfiguration>(
        options =>
        {
            builder.Configuration.GetSection(DataRepositoryConfiguration.SectionName).Bind(options);
        });

    builder.Services.AddDbContext<AgriTagDbContext>(options =>
    {
        options.UseNpgsql(npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorCodesToAdd: null);
        });
    });

    var app = builder.Build();
    Log.Information("Starting AgriTag...");

    // Initialize the Database
    DatabaseInitializer.InitializeDatabase(app);

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Something bad happened!");
}
finally
{
    Log.Information("Shutdown completed.");
    Log.CloseAndFlush();
}