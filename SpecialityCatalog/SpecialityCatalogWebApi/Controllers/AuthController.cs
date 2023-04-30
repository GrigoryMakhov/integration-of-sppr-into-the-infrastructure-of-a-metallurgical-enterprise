using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpecialityCatalogWebApi.Data;
using SpecialityCatalogWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SpecialityCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase

    {
        private readonly StudentsDbContext _studentsDbContext;

        public AuthController(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel data)
        {
            var user = _studentsDbContext.Users.FirstOrDefault(x => x.Name == data.Login && x.Password == data.Password);
            
            if (user == null)
            {
                return new JsonResult(new { status = 1, token = ""});
            }
            
            var claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, data.Login)
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2000)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

             var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return new JsonResult( new { status = 0, token });
        }

    }
}
