using Kutup.Core.Application.Interfaces;
using Kutup.Core.Application.Interfaces.Repositories;
using Kutup.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kutup.Data
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddTransient<IAuthorRepositoryAsync, AuthorRepositoryAsync>();
            services.AddTransient<IBookRepositoryAsync, BookRepositoryAsync>();
            #endregion
        }
    }
}
