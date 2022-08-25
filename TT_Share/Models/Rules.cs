using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class Rules
    {
        [Key]
        [ForeignKey("Campaign")]
        [Column(TypeName = "int")]
        public int Campaign_Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter data")]
        public string Rules_Name { get; set; }
        [ForeignKey("Gifts")]
        [Column(TypeName = "int")]
        [Display(Name = "GiftName")]
        [Required(ErrorMessage = "Please enter data")]
        public int Rules_GiftName { get; set; }//khóa ngoại
        [Column(TypeName = "int")]
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Please enter data")]
        public int Rules_Amount { get; set; }
     
        [Display(Name = "StartTime")]
        [Required(ErrorMessage = "Please enter data")]
        public TimeSpan Rule_StartTime { get; set; }
       
        [Display(Name = "EndTime")]
        [Required(ErrorMessage = "Please enter data")]
        public TimeSpan Rule_EndTime { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "AllDay")]   
        public bool Rule_AllDay { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "Probability")]
        [Required(ErrorMessage = "Please enter data")]
        public int Rules_Probability { get; set; }
        
        public Gifts Gifts { get; set; }
       
        public DateTime Rules_RepeatDaily_StartTime { get; set; }
        public DateTime Rules_RepeatDaily_EndDate { get; set; } 
    }
}
