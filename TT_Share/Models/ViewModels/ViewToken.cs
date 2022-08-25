using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_Share.Models.ViewModels
{
    public class ViewToken
    {
        public string Token { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public int User_Roles { get; set; }
    }
}
