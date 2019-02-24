using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookly.Models;
using System.ComponentModel.DataAnnotations;

namespace Bookly.ViewModels
{
    public class NewCustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public Address Address { get; set; }

    }
}