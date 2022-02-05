using DSRNetSchool.API.Configuration;
using Serilog;

// Configure application
var builder = WebApplication.CreateBuilder(args);

// Logger
builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration
    .Enrich.WithCorrelationId()
    .ReadFrom.Configuration(hostBuilderContext.Configuration);
});


// Configure services
var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppHealthCheck();

services.AddAppCors();

services.AddControllers();

services.AddRazorPages();


var app = builder.Build();

Log.Information("Starting up");

app.UseStaticFiles();

app.UseRouting();

app.UseAppCors();

app.UseAppHealthCheck();

app.UseSerilogRequestLogging();

app.MapRazorPages();

app.MapControllers();

app.Run();
