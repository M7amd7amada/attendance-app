using System.Reflection;

using Microsoft.OpenApi.Models;

using Quartz;

namespace Attendance.Server.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCors(options =>
            options.AddPolicy("Allow All", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                }));

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("V1", new OpenApiInfo
            {
                Title = "Attendance App API",
                Version = "V1",
                Description = "API Services that act as the backend to the Blazoer website."
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
            c.CustomSchemaIds(r => r.FullName);
        });

        builder.Services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();
        });

        builder.Services.AddQuartzHostedService(q =>
            q.WaitForJobsToComplete = true);
    }
}