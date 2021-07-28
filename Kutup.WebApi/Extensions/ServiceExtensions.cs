using Kutup.Core.Application.Interfaces;
using Kutup.Core.Application.Interfaces.Services;
using Kutup.Data.Contexts;
using Kutup.Data.Repositories;
using Kutup.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace Kutup.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KutupDbContext>(
                //opt => opt.UseSqlServer(connectionString)
                //.EnableSensitiveDataLogging()
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
                opt => opt.UseSqlite(connectionString));
        }

        public static void ConfigureKutupServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kutup.WebApi",
                    Version = "v1",
                    Description = "Kutup Projesi Api Servisleri"
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
