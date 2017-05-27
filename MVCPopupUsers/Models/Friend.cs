using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPopupUsers.Models
{
    public class Friend
    {
        [Display(Name = "ID")]
        [Key]
        public int FriendId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }        
        
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]

        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Display(Name = "State")]
        public string State { get; set; }
        
        [Display(Name = "Zip")]
        public string Zip { get; set; }
    }
    public enum MaritalStatuses
    {
        Married,
        Divorced,
        Single,
        Widowed,
        Unknown
    }    
}