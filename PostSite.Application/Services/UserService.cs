using PostSite.Domain.Entities;
using PostSite.Domain.Adapters;
using PostSite.Domain.Adapters.Repositories;
using PostSite.Domain.Services;
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

        public async Task<Response<IUser>> AuthenticationAsync(string email, string password)
        {
            Response<IUser> response = new Response<IUser>();
            Response<IUser> getResponse = await _userRepository.GetAsync(email);
            if (getResponse.Type == ResponseType.Error)
                return getResponse;
            IUser user = getResponse.Data;
            bool isCorrectPassword = _hashAdapter.verify(password, user.PasswordHash);
            if(!isCorrectPassword)
            {
                response.Type = ResponseType.Error;
                response.Message = "Password Incorrect";
                return response;
            }
            user.PasswordHash = "";
            response.Data = user;
            return response;
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
