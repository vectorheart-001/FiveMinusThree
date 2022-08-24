
using FiveMinusThree.Api.Data;
using FiveMinusThree.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FiveMinusThree.Api.Repository.RefreshTokenRepository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly FiveMinusThreeContext _context;
        public RefreshTokenRepository(FiveMinusThreeContext context)
        {
            _context = context;
        }
        public async Task Create(RefreshToken refreshToken)
        {
           await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public async Task Delete(Guid id)
        {
            await _context.Database.ExecuteSqlRawAsync($"DELETE FROM POSTS WHERE ID = {id}");
        }

        public async Task DeleteAll(Guid userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _context.RefreshTokens.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<RefreshToken> GetByToken(string refreshToken)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(u => u.Token == refreshToken);
        }
    }
}
