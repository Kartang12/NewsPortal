using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Contracts.V1;
using News.Contracts.V1.Requests;
using News.Services;

namespace News.Controllers.V1
{
    public class UsersController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager, IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
        }
            
        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_userManager.Users);
        }
        
        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<IActionResult> Get([FromRoute] string userName)
        {
            return Ok(_identityService.GetUserByName(userName));
        }
        
        [HttpPost(ApiRoutes.Users.Add)]
        public async Task<IActionResult> Add([FromBody] UserRegistrationRequest request)
        {
            var registered = await _identityService.RegisterAsync(request.Email, request.Password, request.Role);
            
            if(registered != null)
                return Ok();

            return BadRequest();
        }        
        
        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string userName)
        {
            var result = await _identityService.DeleteUser(userName);
            
            if(result.Succeeded)
                return Ok();

            return BadRequest();
        }
    }
}