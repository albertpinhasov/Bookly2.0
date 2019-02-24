using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookly.Models;

namespace Bookly.Controllers.API
{
    public class BooksController : ApiController
    {
        private BooklyContext _context;

        public BooksController()
        {
           _context = new BooklyContext(); 
        }
        public IHttpActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
