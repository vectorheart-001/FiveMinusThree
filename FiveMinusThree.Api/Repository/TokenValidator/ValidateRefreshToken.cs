using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using FiveMinusThree.Api.Repository.TokenGenerators;

namespace FiveMinusThree.Api.Repository.TokenValidator
{
    public class ValidateRefreshToken
    {
        private readonly AuthenticationConfiguration _configuration;
        public ValidateRefreshToken(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool is_Valid(string refreshToken)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.RefreshTokenSecret)),
                ValidIssuer = _configuration.Issuer,
                ValidAudience = _configuration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero,
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(refreshToken,validationParameters, out SecurityToken secureToken);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
            
        }

    }
}
