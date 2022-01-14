using PostSite.Domain.Entities;
using PostSite.Domain.Utils;

namespace PostSite.Domain.Ports.Driving.Services
{
    public interface IUserService
    {
        public Task<Response<IUser>> Authentication(string email, string password);
        public Task<Response<IUser>> CreateAsync(IUser user, string password);
    }
}
