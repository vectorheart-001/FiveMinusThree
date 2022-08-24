using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FiveMinusThree.Api.Services.TokenServices.TokenGenerators
{
    public class RefreshTokenGenerator
    {
        private readonly AuthenticationConfiguration _configuration;
        public RefreshTokenGenerator(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToke()
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.RefreshTokenSecret));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(_configuration.Issuer,
                _configuration.Audience,
                null,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_configuration.RefreshTokenExpepirationMinutes),
                signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

