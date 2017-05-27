using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPopupUsers.Models
{
    public class State
    {
        [Display(Name = "ID")]
        [Key]
        public int StateId { get; set; }

        [Required]
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        
        [Required]
        [Display(Name = "State Description")]
        public string StateDescription { get; set; }
          
    }
}