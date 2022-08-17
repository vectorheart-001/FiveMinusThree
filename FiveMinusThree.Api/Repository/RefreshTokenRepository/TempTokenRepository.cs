using FiveMinusThree.Api.Models;

namespace FiveMinusThree.Api.Repository.RefreshTokenRepository
{
    public class TempTokenRepository : IRefreshTokenRepository
    {
        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();
        public Task Create(RefreshToken refreshToken)
        {
            refreshToken.Id = Guid.NewGuid();
            _refreshTokens.Add(refreshToken);
            return Task.CompletedTask;
        }

        Task IRefreshTokenRepository.Delete(Guid id)
        {
            _refreshTokens.RemoveAll(x => x.Id == id);
            return Task.CompletedTask;
        }

        Task IRefreshTokenRepository.DeleteAll(Guid userId)
        {
            _refreshTokens.RemoveAll(t => t.UserId == userId);
            return Task.CompletedTask;
        }

        Task<RefreshToken> IRefreshTokenRepository.GetByToken(string refreshToken)
        {
            RefreshToken token = _refreshTokens.FirstOrDefault(x => x.Token == refreshToken);
            return Task.FromResult(token);
        }
    }
}
