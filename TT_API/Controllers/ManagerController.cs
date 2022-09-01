using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT_Share.Models;
using TT_Share.Models.ViewModels;
using TT_Share.Services;

namespace TT_API.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        [ActionName("AddGift")]
        public async Task<IActionResult> AddGift([FromBody] Gifts gifts)
        {
            if (ModelState.IsValid)
            {
                if (await _IManager.AddGift(gifts) > 0)
                {
                    return Ok("Thêm thành công");
                }
            }
            return BadRequest("thiếu dữ liệu");
        }



        //chưa
        [HttpPost]
        [ActionName("AddRule")]
        public async Task<IActionResult> AddRule([FromBody] Rules rules)
        {
            if (ModelState.IsValid)
            {
                if (await _IManager.AddRule(rules) > 0)
                {
                    return Ok("Thêm thành công");
                }
            }
            return BadRequest("thiếu dữ liệu");
        }
        [HttpPut("{id}")]
        [ActionName("UpdateGift")]
        public Gifts UpdateGift( int id, Gifts gifts)
        {

             _IManager.UpdateGift(id, gifts);
            return gifts;

        }


        //chưa
        [HttpPost]
        [ActionName("AddBarcode")]
        public async Task<IActionResult> AddBarCode([FromBody] BarCodes barcode)
        {
            if (ModelState.IsValid)
            {
                if (await _IManager.AddbarCode(barcode) > 0)
                {
                    return Ok("Thêm Thành Công");
                } 
            }
            return BadRequest("thiếu dữ liệu");
        }



        [HttpPost]
        [ActionName("AddScanBarCode")]
        public async Task<IActionResult> AddScanBarCode([FromBody] BarcodeHistory barcodeHistory)
        {
            if (ModelState.IsValid)
            {
                if(await _IManager.ScanBarcode(barcodeHistory) > 0)
                {
                    return Ok("Thêm Thành Công");
                }
            }
            return BadRequest("Thiếu Dữ liệu");
        }
        [HttpGet]
        [ActionName("DetailsCampaign")]
        public  async Task<List<Campaign>> DetailCampaign(int id)
        {
            return await _IManager.CampaignsDetails(id);
        }
        [HttpGet]
        [ActionName("ShowBarcodeHistory")]
        public async Task<List<BarcodeHistory>> BarcodeHistories()
        {
            return await _IManager.GetBarcodeHistory();
        }



        [HttpGet]
        [ActionName("ShowRule")]
        public async Task<List<Rules>> ShowRule()
        {
            return await _IManager.GetRules();
        }
        [HttpGet]
        [ActionName("ShowUser")]
        public async Task<List<Users>> ShowUser()
        {
            return await _IManager.GetUser();
        }

        [HttpPut]
        [ActionName("UpdatePassWord")]
        public async Task<ActionResult> UpdatePass([FromBody] ViewUpdatePassWord viewUpdatePassWord)
        {
            return Ok("đổi mật khẩu thành công");
        }
    }
}
