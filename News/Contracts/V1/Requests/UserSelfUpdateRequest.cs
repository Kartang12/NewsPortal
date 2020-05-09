using System.ComponentModel.DataAnnotations;

namespace News.Contracts.V1.Requests
{
    public class UserSelfUpdateRequest
    {
        [EmailAddress]
        public string Name { get; set; }

        public string Password { get; set; }
    }
}