using FiveMinusThree.Api.Models;
namespace FiveMinusThree.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();
        public Task<User> Create(User user)
        {
            user.Id = Guid.NewGuid();
            users.Add(user);
            return Task.FromResult(user);
        }

        public Task<User> GetByEmail(string email)
        {
            return Task.FromResult(users.FirstOrDefault(u => u.Email == email));
        }

        public Task<User> GetByUserName(string name)
        {
            return Task.FromResult(users.FirstOrDefault(u => u.Name == name));

        }
       

        Task<User> IUserRepository.GetById(Guid id)
        {
            return Task.FromResult(users.FirstOrDefault(u => u.Id == id));
        }
    }
}
