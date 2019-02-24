using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Bookly.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Please enter the First name")]
        [MaxLength(255)]
        [Display(Name = "First name:")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the Last name")]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        public int Id { get; set; }

        //[Required(ErrorMessage = "Address can't be blank")]
        [Display(Name = "Address")]
        public Address Address { get; set; }        

        [Display(Name = "Date of Birth:")]
        [Required(ErrorMessage = "Date of birth can't be blank")]
      //  [ValidateDOB]
        public DateTime DOB { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte? MembershipTypeId { get; set; }

        

    }
}