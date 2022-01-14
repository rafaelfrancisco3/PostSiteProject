using Microsoft.EntityFrameworkCore;
using PostSite.Domain.Entities;
using PostSite.Domain.Ports.Driven.Repositories;
using PostSite.Domain.Utils;
using PostSite.Infra.Data.Models;

namespace PostSite.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IUser>> CreateAsync(IUser user)
        {
            Response<IUser> response = new Response<IUser>();
            await _context.Users.AddAsync((User)user);
            await _context.SaveChangesAsync();
            response.Data = user;
            return response;
        }

        public async Task<Response<IUser>> GetAsync(string email)
        {
            Response<IUser> response = new Response<IUser>();
            IUser? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(user == null)
            {
                response.Type = ResponseType.Error;
                response.Message = "User don't exists";
                return response;
            }
            response.Data = user;
            return response;
        }
    }
}
