using LibrarySystem.Core.Interfaces;
using LibrarySystem.Infrastructure.Data;
using LibrarySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastureConfiguration(this IServiceCollection services, IConfiguration config)
        {

            //services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddDbContext<AppDbContext>(options =>
                                                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
