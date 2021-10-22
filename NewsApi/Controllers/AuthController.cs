using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]

        public IActionResult Login([FromBody] User login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model is not Valid!");
            }

            if (login.Email != "alibiyabani63@gmail.com" && login.Password != "123456")
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:44306/",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Email,login.Email),
                    new Claim(ClaimTypes.Role,"admin")
                },
                expires: DateTime.Now.AddDays(5),
                signingCredentials: signinCredentials

                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { token = tokenString });
        }
    }
}
