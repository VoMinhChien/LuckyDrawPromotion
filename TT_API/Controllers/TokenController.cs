using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TT_Share.Models;
using TT_Share.Models.ViewModels;
using TT_Share.Services;

namespace TT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IUser_Svc _UseSvc;
        public IConfiguration _configuration;
        public TokenController(IUser_Svc UserSvc, IConfiguration configuration)
        {
            _UseSvc = UserSvc;
            _configuration = configuration;
        }
        /// <summary>
        /// đăng nhập (user đăng nhập bằng email , custommer đăng nhập bằng sdt)
        /// </summary>
        /// <param name="viewLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(ViewLogin viewLogin)
        {
            if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.UserEmail) && !string.IsNullOrEmpty(viewLogin.Password) || viewLogin != null && !string.IsNullOrEmpty(viewLogin.UserSDT) && !string.IsNullOrEmpty(viewLogin.Password))
            {
                var users = _UseSvc.Login(viewLogin);
                if (users != null)
                {
                    if (users != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                            new Claim("Id",users.Users_Id.ToString()),
                            new Claim("FullName",users.User_Name),
                            new Claim("Email",users.User_Email),
                            new Claim(ClaimTypes.Role,users.User_Roles.ToString())


                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: singIn);
                        ViewToken viewToken = new ViewToken()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            User_Id = users.Users_Id,
                            User_Name = users.User_Name,                        
                            User_Email=users.User_Email,
                            User_Roles= users.User_Roles.GetHashCode(),
                        };
                        return Ok(viewToken);
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else { return BadRequest(); }
            }
            return BadRequest();
        }
    }
}
