using FiveMinusThree.Api.Models;
namespace FiveMinusThree.Api.Repository.BaseRepository
    //UNUSED INTERFACE - FUTURE REFRACTORING POSSIBLE
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<List<T>> Delete(Guid id);
        
    }
}
