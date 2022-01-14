using Microsoft.Extensions.DependencyInjection;
using PostSite.Application.Services;
using PostSite.Domain.Services;

namespace PostSite.Application
{
    public static class ServiceModuleDependency
    {
        public static void AddPostSiteApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
