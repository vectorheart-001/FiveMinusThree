using FiveMinusThree.Api.Models;
using FiveMinusThree.Api.Data;
using Microsoft.EntityFrameworkCore;
//UNUSED CLASS - FUTUTE REFRACTORING POSSIBLE
namespace FiveMinusThree.Api.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly FiveMinusThreeContext _context;
        private readonly DbSet<T> dbSet;
        public BaseRepository(FiveMinusThreeContext context, DbSet<T> dbSet)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public Task<List<T>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
