using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Model.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ActionCommandGame.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
              return BadRequest(result.Errors);

            }

            return Ok("Registratie gelukt");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserSignInRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Unauthorized("Gebruiker niet gevonden"); 
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Fout wachtwoord");
            }

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id),
              new Claim(ClaimTypes.Email, user.Email!)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
