using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DigitalLibrary.WebApi.Dtos;
using DigitalLibrary.WebApi.Literals;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var key1 = Environment.GetEnvironmentVariable(DigitalLibraryLiterals.JWT_KEY);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key1));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    //issuer: _configuration["JwtIssuer"],
                    //audience: _configuration["JwtAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: creds);

                return Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}



        

