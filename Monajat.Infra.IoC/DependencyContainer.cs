using Microsoft.Extensions.DependencyInjection;
using Monajat.Application.Services.Implementation;
using Monajat.Application.Services.Interface;
using Monajat.Core.Interfaces;
using Monajat.Infra.Data.Repositories;

namespace Monajat.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICheckForUpdateService, CheckForUpdateService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IAudioService, AudioService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICheckForUpdateRepository, CheckForUpdateRepository>();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IAudioRepository, AudioRepository>();

            #endregion
        }

    }
}
