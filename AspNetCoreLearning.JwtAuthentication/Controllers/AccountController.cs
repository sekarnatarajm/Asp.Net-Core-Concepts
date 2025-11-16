using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreLearning.JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(User user)
        {
            string jsonToken = "";
            if (user is null)
            {
                return BadRequest("User object null");
            }
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345-superSecretKey@345-superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                jsonToken = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            }
            return Ok(new AuthenticatedResponse { Token = jsonToken });
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    internal class AuthenticatedResponse
    {
        public string Token { get; set; }
    }
}
