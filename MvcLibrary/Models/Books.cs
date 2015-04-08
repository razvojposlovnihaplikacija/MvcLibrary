using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcLibrary.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Page { get; set; }
    }
    public class BookDBContext:DbContext
    {
        public DbSet<Books> Books { get; set; }
    }
}