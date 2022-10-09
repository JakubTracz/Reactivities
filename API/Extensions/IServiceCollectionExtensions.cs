using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlite(configurationManager.GetConnectionString("Reactivities"));
        });
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policyBuilder =>
            {
                policyBuilder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
            });
        });
        services.AddMediatR(typeof(List.Handler).Assembly);
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        return services;
    }
}