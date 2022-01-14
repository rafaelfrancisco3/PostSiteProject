using PostSite.Domain.Entities;
using PostSite.Domain.Ports.Driven;
using PostSite.Domain.Ports.Driven.Repositories;
using PostSite.Domain.Ports.Driving.Services;
using PostSite.Domain.Utils;

namespace PostSite.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashAdapter _hashAdapter;

        public UserService(IUserRepository userRepository, IHashAdapter hashAdapter)
        {
            _userRepository = userRepository;
            _hashAdapter = hashAdapter;
        }

        public Task<Response<IUser>> Authentication(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IUser>> CreateAsync(IUser user, string password)
        {
            Response<IUser> response = new Response<IUser>();
            Response<IUser> getResponse = await _userRepository.GetAsync(user.Email);
            if (getResponse.Type == ResponseType.Success)
            {
                response.Type = ResponseType.Error;
                response.Message = "User Already Exists";
                return response;
            }
            user.PasswordHash = _hashAdapter.Hash(password);
            Response<IUser> createResponse = await _userRepository.CreateAsync(user);
            return createResponse;
        }
    }
}
