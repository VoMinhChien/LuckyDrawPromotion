using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_Share.Helpers;
using TT_Share.Models;
using TT_Share.Models.ViewModels;

namespace TT_Share.Services
{
    public interface IManager_Svc
    {
        Task<List<Campaign>> GetCampaign();
        Task<List<Gifts>> GetWinerByCampaign(int id);
        Task<List<Rules>> GetRules();
        Task<List<Users>> GetUser();
        Task<List<Campaign>> CampaignsDetails(int id);
        Task<int> ScanBarcode(BarcodeHistory Userbarcodehistory);
        Task<int>AddCampaign(Campaign campaign);
        Task<int> AddGift(Gifts gift);
        int UpdateGift(int id,Gifts gifts);
        Task<int> AddRule(Rules rules);
        Task<int> AddbarCode(BarCodes barCodes);
        int DoiPass(ViewUpdatePassWord viewUpdatePassWord);
    }
    public class Manager_Svc : IManager_Svc
    {
        private readonly DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public Manager_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }

        public async Task<int> AddbarCode(BarCodes barCodes)
        {
            int ret = 0;
            try
            {
                await _context.BarCodes.AddAsync(barCodes);
                await _context.SaveChangesAsync();
                ret = barCodes.BarCodes_Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddCampaign(Campaign campaign)
        {
            int ret = 0;
            try
            {
                
                await _context.Campaigns.AddAsync(campaign);
                await _context.SaveChangesAsync();
                ret = campaign.Campaign_Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddGift(Gifts gift)
        {
            int ret = 0;
            try
            {
                await _context.Giftss.AddAsync(gift);
                await _context.SaveChangesAsync();
                ret = gift.Gifts_Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddRule(Rules rules)
        {
            int ret = 0;
            try
            {
                await _context.Ruless.AddAsync(rules);
                await _context.SaveChangesAsync();
                ret = rules.Rule_Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<Campaign>> CampaignsDetails(int id)
        {
            List<Campaign> details= new List<Campaign> ();
            details=await _context.Campaigns.Where(x=>x.Campaign_Id==id).Include(x=>x.barCodes).Include(x=>x.Gifts).ToListAsync();
            return details;
        }

        public async Task<List<BarcodeHistory>> GetBarcodeHistory()
        {
            List<BarcodeHistory> barcodeHistories = new List<BarcodeHistory>();
            barcodeHistories=await _context.BarcodeHistorys.ToListAsync();
            return barcodeHistories;
        }

        public async Task<List<Campaign>> GetCampaign()
        {
            List<Campaign> campaigns = new List<Campaign>();
            campaigns=await _context.Campaigns.Include(o=>o.barCodes).Include(o=>o.Gifts).ToListAsync();
            return campaigns;
        }

        public async Task<List<Rules>> GetRules()
        {
            List<Rules> rules = new List<Rules>();
            rules = await _context.Ruless.ToListAsync();
            return rules;
        }

        public async Task<List<Users>> GetUser()
        {
             List<Users> users = new List<Users>();
            users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<List<Gifts>> GetWinerByCampaign(int id)
        {
            List<Gifts> WinnerGift=new List<Gifts>();
            WinnerGift=await _context.Giftss.Where(o=>o.Campaign_Id==id).Include(o=>o.winners).ToListAsync();
            return WinnerGift;
        }

        public async Task<int> ScanBarcode(BarcodeHistory Userbarcodehistory)
        {
           int ret=0;
            try
            {
                await _context.BarcodeHistorys.AddAsync(Userbarcodehistory);
                await _context.SaveChangesAsync();
                ret = Userbarcodehistory.BarcodeHistory_Owner;
                if (ret > 0)
                {
                    BarCodes barCodes = new BarCodes();
                    barCodes = await _context.BarCodes.Where(o => o.Campaign_Id == Userbarcodehistory.Barcode_Id).FirstOrDefaultAsync();
                    barCodes.BarCodes_Scanned += 1;
                    _context.BarCodes.Update(barCodes);
                    await _context.SaveChangesAsync();                
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int UpdateGift(int id,Gifts gifts)
        {
            int ret = 0;
            try
            {
                Gifts _gift = null;
                _gift = _context.Giftss.Find(id);
                _gift.Gifts_Product = gifts.Gifts_Product;
                _gift.Gifts_Description = gifts.Gifts_Description;
                _gift.Gifts_CodeCount = gifts.Gifts_CodeCount;
                _gift.CreateDate = DateTime.Now;
                _gift.Campaign_Id = gifts.Campaign_Id;
                _context.Update(_gift);
                _context.SaveChanges();
                ret = _gift.Gifts_Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public int DoiPass(ViewUpdatePassWord viewUpdatePassWord)
        {

            var u = _context.Users.Where(p => p.Users_Id.Equals(viewUpdatePassWord.IdUsers) && p.User_Password.Equals(_maHoaHelper.Mahoa(viewUpdatePassWord.Password))).FirstOrDefault();
            if (u != null)
            {
                int ret = 0;
                try
                {
                    Users _user = null;
                    _user = _context.Users.Find(u.Users_Id);
                    _user.User_Password = _maHoaHelper.Mahoa(viewUpdatePassWord.PasswordNew);
                    _user.User_Password2 = _maHoaHelper.Mahoa(viewUpdatePassWord.PasswordNew);
                    _context.Update(_user);
                    _context.SaveChanges();
                    ret = _user.Users_Id;
                }
                catch
                {
                    ret = 0;
                }
                return ret;
            }
            return 0;

        }

    }
}
