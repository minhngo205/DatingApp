using DatingApp.DatingApp.API.Database;
using DatingApp.DatingApp.API.Profiles;
using DatingApp.DatingApp.API.Repositories;
using DatingApp.DatingApp.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config ){
            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepos,UserRepos>();
            services.AddScoped<IUserLikeRepos, UserLikeRepos>();
            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}