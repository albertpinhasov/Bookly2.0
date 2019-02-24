using Bookly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookly.ViewModels
{
    public class AddBookViewModel
    {
        public Book Book { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }
}