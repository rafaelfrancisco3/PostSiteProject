using PostSite.Domain.Entities;
using PostSite.Domain.Utils;

namespace PostSite.Domain.Services
{
    public interface IUserService
    {
        public Task<Response<IUser>> AuthenticationAsync(string email, string password);
        public Task<Response<IUser>> CreateAsync(IUser user, string password);
    }
}
