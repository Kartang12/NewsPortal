namespace News.Contracts.V1.Responses
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }
    }
}