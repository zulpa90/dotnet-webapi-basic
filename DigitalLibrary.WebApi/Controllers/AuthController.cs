using DigitalLibrary.WebApi.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequetDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.email,
                Email = model.email
            };

            var result = await _userManager.CreateAsync(user, model.password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered successfully");

        }
    }
}



        

