

using News.Domain;
using System;
using System.Threading.Tasks;

namespace News.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
