using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wpm.Infra.Data;
using Wpm.Infra.Data.Repository;
using Wpm.Management.Domain.Repository.Interfaces;

namespace Wpm.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Lê a connection string do appsettings.json
            var connectionString = "Data source=WpmManagement.db";

            // Registra o DbContext
            services.AddDbContext<ManagementDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped<IManagementRepository, ManagementRepository>();

            return services;
        }
    }
    public static class ManagementDbContextExtensions
    {
        public static void EnsureDatabaseIsCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ManagementDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.CloseConnection();
        }
    }
}
