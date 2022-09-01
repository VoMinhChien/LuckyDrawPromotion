using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Share.Models
{
    public class Campaign
    {
        [Key]
        [Column(TypeName = "int")]  
        public int Campaign_Id { get; set; }
        [Required]
       
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Name")]     
        public string Campaign_Name { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "Compaign_Type")]
        public bool Compaihn_Type { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "AutoUpdate")]
        public bool AutoUpdate { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "ApplyForAll")]
        public bool ApplyForAll { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "LimitOneCampaignToOneCustomer")]
        public bool LimitOneCampaignToOneCustomer { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "CodeUsageLimit")]
        public int CodeUsageLimit { get; set; }
        [Column(TypeName = "bit")]
        [Display(Name = "Unlimited")]
        public bool Unlimited { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "CodeCount")]
        public int CodeCount { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Charset")]
        public string Charset { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "CodeLength")]
        public int CodeLength { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "CodeCount")]
        public string Prefix { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Postfix")]
        public string Postfix { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        public ICollection<BarCodes> barCodes { get; set; }
        public ICollection<Gifts> Gifts { get; set; }

    }
}
