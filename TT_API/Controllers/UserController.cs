using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TT_Share.Models;
using TT_Share.Services;

namespace TT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser_Svc _UserSvc;
        public UserController(IUser_Svc UserSvc)
        {
            _UserSvc = UserSvc;
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostUser(Users users)
        {
            try
            {
                int id = await _UserSvc.AddUserAsync(users);
                users.Users_Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
