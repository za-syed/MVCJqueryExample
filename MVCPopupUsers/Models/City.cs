using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPopupUsers.Models
{
    public class City
    {
        [Display(Name = "ID")]
        [Key]
        public int CityId { get; set; }
        
        [Required]
        [Display(Name = "City Code")]
        public string CityCode { get; set; }

        [Required]
        [Display(Name = "City Desc")]
        public string CityDesc { get; set; }

        [Required]
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        
    }
}