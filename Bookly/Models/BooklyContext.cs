using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Bookly.Models
{
    public class BooklyContext : DbContext
    {
       public DbSet<Book> Books { get; set; }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<BookStatus> BookStatus  { get; set; }
       public DbSet<MembershipType> MembershipTypes { get; set; }
       public DbSet<Address> Addresses { get; set; }
       public DbSet<BookCategory> BookCategories { get; set; }

    }
}