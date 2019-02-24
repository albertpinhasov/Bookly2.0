using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookly.Models
{
    public class MembershipType
    {
        [Display(Name = "Membership Type")]
        public byte Id { get; set; }
        public int Fee { get; set; }
        public int DurationInMonths { get; set; }
        public string Name { get; set; }

    }
}