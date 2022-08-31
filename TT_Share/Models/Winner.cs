using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class Winner
    {
        [Key]
        [Column(TypeName = "int")]
        public int Winners_Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Users")]
        [Required(ErrorMessage = "Please enter data")]
        public int Winners_UserID{ get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Invalid phone number.")]
        [Display(Name = "PhoneNumber")]
        public string Winners_PhoneNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter data")]
        public string Winners_Address { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "Windate")]
        [Required(ErrorMessage = "Please enter data")]
        public DateTime Winners_Windate { get; set; }
        [ForeignKey("gifts")]
        [Display(Name = "GiftName ")]
        [Required(ErrorMessage = "Please enter data")]
        public int Winners_GiftId { get; set; }//khóa ngoại
        [Column(TypeName = "bit")]
        [Display(Name = "SentGift ")]
       public Gifts gifts { get; set; }
        public bool Winners_SentGift { get; set; }
        
    }
}
