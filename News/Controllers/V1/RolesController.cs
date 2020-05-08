using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Contracts.V1;

namespace News.Controllers.V1
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet(ApiRoutes.Roles.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_roleManager.Roles);
        }

    }
}