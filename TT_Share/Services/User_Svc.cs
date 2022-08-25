
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
    }
}
