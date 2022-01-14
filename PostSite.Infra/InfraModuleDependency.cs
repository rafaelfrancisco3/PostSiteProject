using Microsoft.Extensions.DependencyInjection;
using PostSite.Infra.Data;
using PostSite.Domain.Adapters;
using PostSite.Infra.Adapters;
using PostSite.Domain.Adapters.Repositories;
using PostSite.Infra.Data.Repositories;

namespace PostSite.Infra
{
    public static class InfraModuleDependency
    {
        public static void AddPostSiteInfra(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IHashAdapter, HashAdapter>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
