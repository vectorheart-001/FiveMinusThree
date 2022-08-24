using FiveMinusThree.Api.Data;
using Microsoft.EntityFrameworkCore;
using FiveMinusThree.Api.Models;
namespace FiveMinusThree.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly FiveMinusThreeContext _context;
        public UserRepository(FiveMinusThreeContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
             _context.Users.Add(user);
             await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByUserName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }
       

        async Task<User> IUserRepository.GetById(Guid id)
        {
             return await _context.Users.FindAsync(id);
        }
    }
}
