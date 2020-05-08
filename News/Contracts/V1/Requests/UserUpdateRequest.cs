using System.ComponentModel.DataAnnotations;

namespace News.Contracts.V1.Requests
{
    public class UserUpdateRequest
    {
        [EmailAddress]
        public string Name { get; set; }

        public string Role { get; set; }
    }
}