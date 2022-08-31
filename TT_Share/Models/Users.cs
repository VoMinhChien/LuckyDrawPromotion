using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TT_Share.Models
{
    public enum Role
    {
        [EnumMember(Value = "Admin")]
        [Display(Name = "Admin")]
        Admin,
        [EnumMember(Value = "Customer")]
        [Display(Name = "KhachHang")]
        Customer,
    }
    public class Users
    {
        [Key]
        [Column(TypeName = "int")]
        public int Users_Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter data")]
        public string User_Name { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string User_Email { get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Invalid phone number.")]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Display(Name = "DateOfBirth")]
        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "Please enter data")]
        public DateTime DataOfBirth { get; set; }
        [Display(Name = "Position")]
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Please enter data")]
        public string Position { get; set; }
        [Display(Name = "TypeOfBusiness")]
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Please enter data")]
        public string TypeOfBusiness { get; set; }
        [Display(Name = "Location")]
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Please enter data")]
        public string Location { get; set; }
        [Display(Name = "PassWord")]
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu")]
        [Column(TypeName = "nvarchar(50)"), MaxLength(50)]
        public string User_Password { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("User_Password", ErrorMessage = "Re-typed password does not match.")]
        public string User_Password2 { get; set; }
        [Display(Name = "Chức danh")]
        [Column(TypeName = "nvarchar(100)")]
        public Role User_Roles { get; set; }
        public int NumberOfTurns { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "Block")]    
        public bool IsDelete { get; set; }
        public ICollection<BarcodeHistory> BarcodeHistorys { get; set; }

    }
}
