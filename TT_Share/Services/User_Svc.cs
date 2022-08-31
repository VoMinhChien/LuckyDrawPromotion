
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
    public  interface IUser_Svc
    {
        Task<int> AddUserAsync(Users users);
        int AddUser(Users users);
        Task<Users> LoginAsync(ViewLogin viewLogin);
        Users Login(ViewLogin viewLogin);
        Task<bool> Spin(ViewSpin viewSpin);
        Task<List<Winner>> GetAllWinner();
        Task<List<Winner>> GetAllWinnerByPhoneNumber(string search);
        Task<List<Winner>> GetAllWinnerByUser(int id);
        Task<int> ProfileUpdate(int id,Users users);
    }
    public class User_Svc:IUser_Svc
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public User_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public Users Login(ViewLogin viewLogin)
        {
            var u = _context.Users.Where(p => p.User_Email.Equals(viewLogin.UserEmail)&& p.User_Password.Equals(_maHoaHelper.Mahoa(viewLogin.Password)) 
            || p.PhoneNumber.Equals(viewLogin.UserSDT) && p.User_Password.Equals(_maHoaHelper.Mahoa(viewLogin.Password))).FirstOrDefault();
            return u;
        }
        public async Task<Users> LoginAsync(ViewLogin viewLogin)
        {
            var u = await _context.Users.
                Where(p => p.User_Email.Equals(viewLogin.UserEmail) && p.User_Password
                .Equals(_maHoaHelper.Mahoa(viewLogin.Password))).FirstOrDefaultAsync();
            return u;
        }
        public Task<int> AddUserAsync(Users users)
        {
            int ret = 0;
            try
            {
                users.User_Roles = Role.Customer;
                users.User_Password = _maHoaHelper.Mahoa(users.User_Password);
                users.User_Password2 = users.User_Password;
                _context.AddAsync(users);
                _context.SaveChanges();
                ret = users.Users_Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }
        public int AddUser(Users users)
        {
            int ret = 0;
            try
            {
                users.User_Password = _maHoaHelper.Mahoa(users.User_Password);
                users.User_Password2 = users.User_Password;
                _context.Add(users);
                _context.SaveChanges();
                ret = users.Users_Id;

            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<bool> Spin(ViewSpin viewSpin)
        {
            Users users = new Users();
            users = await _context.Users.Where(o => o.Users_Id == viewSpin.User_Id).FirstOrDefaultAsync();
            if (users.NumberOfTurns < 1)
            {
                return false;
            }
            else
            {
                users.NumberOfTurns -= 1;
                _context.Update(users);
                await _context.SaveChangesAsync();
                if (viewSpin.Gift_Id > 0)
                {
                    Gifts gifts = new Gifts();
                    gifts = await _context.Giftss.Where(o => o.Gifts_Id == viewSpin.Gift_Id).FirstOrDefaultAsync();
                    gifts.Gifts_CodeCount -= 1;
                    _context.Update(gifts);
                    await _context.SaveChangesAsync();
                    Winner winner = new Winner();
                    winner.Winners_UserID = viewSpin.User_Id;
                    winner.Winners_GiftId= viewSpin.Gift_Id;    
                    winner.Winners_Windate=DateTime.Now;
                    winner.Winners_SentGift = false;
                    winner.Winners_PhoneNumber = users.PhoneNumber;
                    winner.Winners_Address = "null";
                    await _context.Winners.AddAsync(winner);
                    await _context.SaveChangesAsync();     
                 }
                return true;
            }
            
        }

        public async Task<List<Winner>> GetAllWinner()
        {
            List<Winner> ListWinners = new List<Winner>();
            ListWinners = await _context.Winners.OrderByDescending(o => o.Winners_Windate).ToListAsync();
            return ListWinners;
        }

        public async Task<List<Winner>> GetAllWinnerByPhoneNumber(string search)
        {
            List<Winner> ListWinners = new List<Winner>();
            ListWinners= await _context.Winners.Where(o=>o.Winners_PhoneNumber.Contains(search)).ToListAsync();
            return ListWinners;
        }

        public async Task<int> ProfileUpdate(int id,Users users)
        {
           int ret = 0;
            try
            {
                Users _users = null;
                _users = _context.Users.Find(id);
                _users.User_Name = users.User_Name;
                _users.User_Email = users.User_Email;
                _users.NumberOfTurns= users.NumberOfTurns;
                _users.Location = users.Location;
                _users.DataOfBirth=users.DataOfBirth;
                _users.Position=users.Position;
                _users.TypeOfBusiness = users.TypeOfBusiness;
                _users.User_Password=users.User_Password;
                _users.User_Password2=users.User_Password2;
                _users.User_Roles = users.User_Roles;
                _users.NumberOfTurns=users.NumberOfTurns;
                _context.Users.Update(_users);
                await _context.SaveChangesAsync();
                ret = _users.Users_Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<Winner>> GetAllWinnerByUser(int id)
        {
            List<Winner> listgiftbyusers = new List<Winner>();
            listgiftbyusers = await _context.Winners.Where(o=>o.Winners_UserID==id).Include(o=>o.gifts).ToListAsync();
            return listgiftbyusers;
        }
    }
}
