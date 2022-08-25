using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_Share.Models.ViewModels
{
    public class ViewLogin
    {
        
        public string UserSDT { get; set; }
        
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
