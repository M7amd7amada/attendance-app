using System.Reflection;

using Attendance.Server.Authorization;
using Attendance.Server.Data;
using Attendance.Server.Models;
using Attendance.Server.Repositories;
using Attendance.Server.Services;
using Attendance.Shared.Interfaces;

using Blazorcrud.Server.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Quartz;

namespace Attendance.Server.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("SqlServer");

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<IJwtUtils, JwtUtils>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        builder.Services.AddScoped<IUserRepository, UserRepostiory>();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Filename=./attendance-app.sqlite"));


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
            q.AddJobAndTrigger<UploadProcessorJob>(builder.Configuration);
        });

        builder.Services.AddQuartzHostedService(q =>
            q.WaitForJobsToComplete = true);
        builder.Services.Configure<AppSettings>(builder.
            Configuration.GetSection("AppSettings"));
    }
}