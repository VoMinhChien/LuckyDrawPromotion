using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class Gifts
    {
        [Key]
        [ForeignKey("Campaign")]
        [Column(TypeName = "int")]
        public int Campaign_Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Please enter data")]
        public string Gifts_Product { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter data")]
        public string Gifts_Description { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "CodeCount")]
        [Required(ErrorMessage = "Please enter data")]
        public int Gifts_CodeCount { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }
        public virtual Campaign Campaign { get; set; }  
    
    }
}
