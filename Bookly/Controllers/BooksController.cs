using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Bookly.Models;
using Bookly.ViewModels;

namespace Bookly.Controllers
{
    public class BooksController : Controller
    {
        private BooklyContext _context;
        // GET: Book
        public BooksController()
        {
            _context = new BooklyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var books = _context.Books.Include(cat => cat.BookCategory).ToList();
           
            

            return View(books);
        }
        public ActionResult Add()
        {
            var categories = _context.BookCategories.ToList();

            var viewModel = new AddBookViewModel
            {
                BookCategories = categories
            };

            return View("AddBookForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var book = _context.Books.Single(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new AddBookViewModel
            {
                Book = book,
                BookCategories = _context.BookCategories.ToList()
            };

            return View("AddBookForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddBookViewModel
                {
                    Book = book,
                    BookCategories = _context.BookCategories.ToList()
                };
                return View("AddBookForm", viewModel);
            }

            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var updateBookInfo = _context.Books.Single(b => b.Id == book.Id);
                updateBookInfo.Author = book.Author;
                updateBookInfo.ISBN = book.ISBN;
                updateBookInfo.Name = book.Name;
                updateBookInfo.Publisher = book.Publisher;
                updateBookInfo.YearPublished = book.YearPublished;
                updateBookInfo.BookCategoryId = book.BookCategoryId;

            }

            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
            return RedirectToAction("Add", "Books");
        }    
        [Route("books/releasedate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
            
            
    }
}