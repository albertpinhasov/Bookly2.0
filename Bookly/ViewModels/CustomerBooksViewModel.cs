using Bookly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookly.ViewModels
{
    public class CustomerBooksViewModel
    {
        public Customer Customer { get; set; }
        public List<Book> Books { get; set; }
        public List<BookStatus> BookStatuses { get; set; }

    }
}