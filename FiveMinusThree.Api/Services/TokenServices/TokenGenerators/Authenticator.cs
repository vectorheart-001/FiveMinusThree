using FiveMinusThree.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using FiveMinusThree.Api.Repository.RefreshTokenRepository;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FiveMinusThree.Api.Services.TokenServices.TokenGenerators
{
    public class Authenticator
    {
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public Authenticator(AccessTokenGenerator accessTokenGenerator, RefreshTokenGenerator refreshTokenGenerator, IRefreshTokenRepository refreshTokenRepository)
        {
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthenticatedUserResponse> Authenticate(User user)
        {
            string accessToken = _accessTokenGenerator.GenerateToken(user);
            string refershToken = _refreshTokenGenerator.GenerateToke();
            RefreshToken refreshTokenDTO = new RefreshToken
            {
                Token = refershToken,
                UserId = user.Id,
            };
            await _refreshTokenRepository.Create(refreshTokenDTO);
            return new AuthenticatedUserResponse
            {
                AccessToken = accessToken,
                RefreshToken = refershToken
            };
        }
    }
}
