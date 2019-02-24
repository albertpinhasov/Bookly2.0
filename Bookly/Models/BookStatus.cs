using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookly.Models
{
    public class BookStatus
    {
       public int Id { get; set; }
        public Book Book { get; set; }             
        public Customer Customer { get; set; }
    }
}