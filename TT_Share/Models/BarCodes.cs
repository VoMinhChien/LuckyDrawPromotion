using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class BarCodes
    {
        [Key]
        [Column(TypeName = "Int")]
        public int BarCodes_Id { get; set; }
        public string BarCodes_Code { get; set; }//khóa ng
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "BarCode")]
        public string BarCodes_BarCodes { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "QRCodes ")]
        public string BarCodes_QRCode { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "CreateDate ")]
        public DateTime BarCodes_CreatedDate { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "ExpireDate ")]
        public DateTime BarCodes_ExpiredDate { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "ScannedDate ")]
        public DateTime BarCodes_ScannedDate { get; set; }
        [Column(TypeName = "Int")]
        [Display(Name = "Scanned ")]
        public int BarCodes_Scanned { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "Active ")]
        public bool BarCodes_Active { get; set; }
        [ForeignKey("Campaign")]
        public int Campaign_Id { get; set; }
        public virtual Campaign Campaign { get; set; }
        
        public Winner Winner { get; set; }
        public ICollection<BarcodeHistory> BarcodeHistorys { get; set; }
    }
}
