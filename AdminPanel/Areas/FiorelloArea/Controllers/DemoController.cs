using AdminPanel.DAL;
using AdminPanel.Models.DemoEntities;
using AdminPanel.ViewModels.AdminBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdminPanel.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DemoController : Controller
    {
        private readonly AppContext _appDbContext;
        public DemoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var books=_appDbContext.Books
                .Include(b =>b.BookGenres).
                ThenInclude(bg=>bg.Genre).
                Include(b => b.BookAuthors).
                ThenInclude(ba=>ba.Author).
                ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.Authors=_appDbContext.Authors.ToList();
            ViewBag.Genres=_appDbContext.Genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBookVM createBookVM)
        {
            ViewBag.Authors = _appDbContext.Authors.ToList();
            ViewBag.Genres = _appDbContext.Genres.ToList();
            Book book = new();
            book.Title = createBookVM.Name;
            

            foreach(var genreId in createBookVM.GenreIds)
            {
                BookGenres bookGenre = new();
                bookGenre.BookId = book.Id;
                bookGenre.GenreId = genreId;
                book.BookGenres.Add(bookGenre);
            }
            foreach (var authorId in createBookVM.AuthorIds)
            {
                BookAuthor bookAuthor = new();
                bookAuthor.BookId = book.Id;
                bookAuthor.AuthorId = authorId;
                book.BookAuthors.Add(bookAuthor);

            }
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
            


            return RedirectToAction ("index");
        }
    }
}
