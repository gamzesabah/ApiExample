
using Core.Utilities.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            AddCoreInstances(services, configuration);

            return services;
        }

        private static void AddCoreInstances(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddSingleton<IUserService, UserService>();

            var loggedInUsers = new LoggedInUsers();
            configuration.Bind(nameof(loggedInUsers), loggedInUsers);
            services.AddSingleton(loggedInUsers);
        }
    }
}
