using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class BarcodeHistory
    {
        [Key]
        public int BarcodeHistory_Id { get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string BarcodeHistory_Code { get; set; }//khoa ng
        [Column(TypeName = "DateTime")]
        [Display(Name = "CreateDate")]
        public DateTime BarcodeHistory_CreatedDate { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "ScannedDate")]
        public DateTime BarcodeHistory_ScannedDate { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "SpinDate")]
        public DateTime BarcodeHistory_SpinDate { get; set; }
        [Column(TypeName = "Int")]
        [ForeignKey("users")]
        [Display(Name = "Owner")]
        public int BarcodeHistory_Owner { get; set; }
        [Column(TypeName = "Int")]
        [Display(Name = "Scanned")]
        public int BarcodeHistory_Scanned { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "UsedForSpin")]
        public bool BarcodeHistory_UsedForSpin { get; set; }
        [ForeignKey("BarCodes")]
        [Column(TypeName = "Int")]
        public int Barcode_Id { get;set; }


        public BarCodes BarCodes { get; set; }
        public virtual Users users { get; set; }
    }
}
