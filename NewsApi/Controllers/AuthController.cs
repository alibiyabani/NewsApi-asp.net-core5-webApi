using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsApi.Core.Security;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;
        private readonly IConfiguration _config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }


        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            var adminEmail = _config.GetValue<string>("AppSettings:Email");
            var secretToken = _config.GetValue<string>("AppSettings:IssuerSigningKey");

            if (!ModelState.IsValid)
            {
                return BadRequest("The Model is not Valid!");
            }

            if (_userService.IsExist(login.UserName, HashPassword.EncodePasswordMd5(login.Password)))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretToken));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44306/",
                    claims: new List<Claim>
                    {
                    new Claim(ClaimTypes.Email,adminEmail),
                    new Claim(ClaimTypes.Role,"admin")
                    },
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: signinCredentials

                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new { token = tokenString });
            }

            return Unauthorized(adminEmail);

        }
    }
}
