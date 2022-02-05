namespace DSRNetSchool.API.Configuration;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

/// <summary>
/// Register services 
/// </summary>
public static class HealthCheckConfiguration
{
    /// <summary>
    /// Register services
    /// </summary>
    /// <param name="services">Services collection</param>
    public static IServiceCollection AddAppHealthCheck(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<ExampleHealthCheck>("DSRNetSchool.API");

        return services;
    }

    /// <summary>
    /// Use service
    /// </summary>
    /// <param name="app">Application</param>
    public static void UseAppHealthCheck(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions()
        {
            ResponseWriter = WriteHealthCheckResponse,
            AllowCachingResponses = false,
        });
    }

    private static async Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport report)
    {
        httpContext.Response.ContentType = "application/json";
        var response = new HealthCheckResponse()
        {
            OverallStatus = report.Status.ToString(),
            TotalDuration = report.TotalDuration.TotalSeconds.ToString("0:0.00"),
            HealthChecks = report.Entries.Select(x => new HealthCheck
            {
                Status = x.Value.Status.ToString(),
                Component = x.Key,
                Description = x.Value.Description == null ? "" : x.Value.Description,
                Duration = x.Value.Duration.TotalSeconds.ToString("0:0.00")
            }),

        };

        await httpContext.Response.WriteAsync(text: JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
    }

    private class HealthCheck
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }

    private class HealthCheckResponse
    {
        public string OverallStatus { get; set; }
        public IEnumerable<HealthCheck> HealthChecks { get; set; }
        public string TotalDuration { get; set; }
    }
}