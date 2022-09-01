using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT_Share.Models;
using TT_Share.Models.ViewModels;
using TT_Share.Services;

namespace TT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser_Svc _UserSvc;
        public UserController(IUser_Svc UserSvc)
        {
            _UserSvc = UserSvc;
        } 
        /// <summary>
        /// đăng kí tài khoản
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("register")]
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
        /// <summary>
        /// quay vòng quay may mắn
        /// </summary>
        /// <param name="viewSpin"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("Spin")]
        public async Task<IActionResult> Spin([FromBody] ViewSpin viewSpin)
        {
            bool ret = await _UserSvc.Spin(viewSpin);
            if (ret)
            {
                return Ok("Bạn đã mất 1 lượt");
            }
            else
            {
                return BadRequest("Bạn không có lượt nào để quay, quét mã để nhận thêm lượt nhé");
            }
        }
        /// <summary>
        /// hiển thị danh sách các người chơi đã quét mã
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Winner>>> GetAllWiner()
        {

            return await _UserSvc.GetAllWinner();
            //show tất cả danh sách winer
        }
        /// <summary>
        /// tìm kiếm người chơi đã quay (đầu vào là sdt)
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Winner>>> GetWinnerByPhoneNumber(string search)
        {

            return await _UserSvc.GetAllWinnerByPhoneNumber(search);
            //show winner theo id
        }
        /// <summary>
        /// sửa thông tin cá nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Users SuaThongTin(int id, Users users)
        {
            _UserSvc.ProfileUpdate(id, users);
            return users;
        }
        /// <summary>
        /// hiển thị lịch sử quay cá nhân
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("getGiftByWinner")]
        public async Task<ActionResult<IEnumerable<Winner>>> GetAllGiftByWinner(int id)
        {
            return await _UserSvc.GetAllWinnerByUser(id);
        }
    }
}
