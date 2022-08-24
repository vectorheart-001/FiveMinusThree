namespace FiveMinusThree.Api.Services.TokenServices.TokenGenerators
{
    public class AuthenticatedUserResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
