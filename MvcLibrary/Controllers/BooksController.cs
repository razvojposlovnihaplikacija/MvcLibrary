using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models;

namespace MvcLibrary.Controllers
{
    public class BooksController : Controller
    {
        private BookDBContext db = new BookDBContext();

        //
        // GET: /Books/
        public ActionResult SearchIndex(string bookAuthor, string searchString)
        {
            var AuthorLst = new List<string>();
            var AuthorQry = from d in db.Books
                           orderby d.Author
                           select d.Author;
            AuthorLst.AddRange(AuthorQry.Distinct());
            ViewBag.bookAuthor = new SelectList(AuthorLst);
            var books = from m in db.Books
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }
            if (string.IsNullOrEmpty(bookAuthor))
                return View(books);
            else
            {
                return View(books.Where(x => x.Author == bookAuthor));
            }
        }
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        //
        // GET: /Books/Details/5

        public ActionResult Details(int id = 0)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books);
        }

        //
        // GET: /Books/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // POST: /Books/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        //
        // GET: /Books/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // POST: /Books/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}