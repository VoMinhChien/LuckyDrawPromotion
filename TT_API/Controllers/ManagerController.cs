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
        /// <summary>
        /// hiển thị danh sách  Campaign
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetAllCampaign()
        {

            return await _IManager.GetCampaign();
            //show tất cả danh sách campaign
        }
        /// <summary>
        /// Show danh sách người thắng thông qua từng chiến dịch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Gifts>>>GetWinerByCampaign(int id)
        {
            return await _IManager.GetWinerByCampaign(id);
        }
        /// <summary>
        /// Tạo Chiến Dịch mới
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Tạo Gift mới
        /// </summary>
        /// <param name="gifts"></param>
        /// <returns></returns>
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



        /// <summary>
        /// Tạo Rules mới
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
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
        /// <summary>
        /// cập nhật gift
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gifts"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ActionName("UpdateGift")]
        public Gifts UpdateGift( int id, Gifts gifts)
        {

             _IManager.UpdateGift(id, gifts);
            return gifts;

        }

        /// <summary>
        /// thêm Barcode mới
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
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


        /// <summary>
        ///  quét mã barcode
        /// </summary>
        /// <param name="barcodeHistory"></param>
        /// <returns></returns>
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
        /// <summary>
        /// hiển thị chi tiết chiến dịch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("DetailsCampaign")]
        public  async Task<List<Campaign>> DetailCampaign(int id)
        {
            return await _IManager.CampaignsDetails(id);
        }
        /// <summary>
        /// hiển thị lịch sử quét mã
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("ShowBarcodeHistory")]
        public async Task<List<BarcodeHistory>> BarcodeHistories()
        {
            return await _IManager.GetBarcodeHistory();
        }
        /// <summary>
        /// hiển thị tất cả rules
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("ShowRule")]
        public async Task<List<Rules>> ShowRule()
        {
            return await _IManager.GetRules();
        }
        /// <summary>
        /// hiển thị tất cả users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("ShowUser")]
        public async Task<List<Users>> ShowUser()
        {
            return await _IManager.GetUser();
        }
        /// <summary>
        /// đổi mật khẩu
        /// </summary>
        /// <param name="viewUpdatePassWord"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdatePassWord")]
        public async Task<ActionResult> UpdatePass([FromBody] ViewUpdatePassWord viewUpdatePassWord)
        {
            if ( _IManager.DoiPass(viewUpdatePassWord) >0 )
            {
                return Ok("đổi pass thành công");
            }
            else
            {
                return BadRequest("Mật khẩu cũ sai");
            }
            
        }
    }
}
