using PostSite.Domain.Entities;
using PostSite.Domain.Utils;

namespace PostSite.Domain.Adapters.Repositories
{
    public interface IUserRepository
    {
        public Task<Response<IUser>> CreateAsync(IUser user);
        public Task<Response<IUser>> GetAsync(string email);
    }
}
