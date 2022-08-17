namespace FiveMinusThree.Api.Repository.TokenGenerators
{
    public class AuthenticatedUserResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
