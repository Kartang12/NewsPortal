namespace News.Contracts.V1.Responses
{
    public class AuthSuccessResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }
    }
}