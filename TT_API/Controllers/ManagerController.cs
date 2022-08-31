using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT_Share.Models;
using TT_Share.Services;

namespace TT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        public IManager_Svc _IManager;
        public ManagerController(IManager_Svc ManagerSvc)
        {
            _IManager = ManagerSvc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetAllCampaign()
        {

            return await _IManager.GetCampaign();
            //show tất cả danh sách campaign
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Gifts>>>GetWinerByCampaign(int id)
        {
            return await _IManager.GetWinerByCampaign(id);
        }
        [HttpPost]
        [ActionName("AddCampaign")]
        public async Task<IActionResult> AddCampaign([FromBody] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                if (await _IManager.AddCampaign(campaign) > 0)
                {
                    return Ok("Thêm thành công");
                } 
            }
            return BadRequest("thiếu dữ liệu");
        }
    }
}
