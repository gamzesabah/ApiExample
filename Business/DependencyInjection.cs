using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Business.Repository;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(
        this IServiceCollection services,
        IConfiguration configuration)
        {

            AddPersistence(services, configuration);

            return services;
        }

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Singleton);

            services.AddTransient<IProductService, ProductManager>();
            services.AddTransient<IProductDal, EfProductDal>();

            services.AddTransient<IUserCustomService, UserCustomManager>();
            services.AddTransient<IUserDal, EfUserDal>();

            services.AddSingleton<IAuthService, AuthManager>();
            services.AddSingleton<ITokenHelper, JwtHelper>();
        }
    }
}
