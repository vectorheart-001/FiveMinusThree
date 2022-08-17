using FiveMinusThree.Api.Models;
namespace FiveMinusThree.Api.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByUserName(string name);
        Task<User> Create(User user);
        Task<User> GetById(Guid id);
    }
}
