using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class Gifts
    {
        [Key]
        public int Gifts_Id { get; set; }
        [ForeignKey("campaign")]
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
        public Campaign campaign { get; set; }
        public virtual Rules Rules { get; set; }
        public ICollection<Winner> winners { get; set; }
       
    }
}
