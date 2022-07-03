using Microsoft.AspNetCore.Mvc;
using PersonalBookLibraryWeb.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace PersonalBookLibraryWeb.Controllers
{
    public class HomeController : Controller
    {
        private BooksContext db;

        public HomeController(BooksContext _db)
        {
            db = _db;
        }

        // read
        [HttpGet]
        public async Task<IActionResult> Index(SortState sortOrder = SortState.BookNameAsc)
        {
            IQueryable<Book> books = db.Books;
            ViewData["BookNameSort"] = sortOrder == SortState.BookNameAsc ? SortState.BookNameDesc : SortState.BookNameAsc;
            ViewData["AuthorNameSort"] = sortOrder == SortState.AuthorNameAsc ? SortState.AuthorNameDesc : SortState.AuthorNameAsc;
            ViewData["RatingSort"] = sortOrder == SortState.RatingAsc ? SortState.RatingDesc : SortState.RatingAsc;
            ViewData["ShortDescriptionSort"] = sortOrder == SortState.ShortDescriptionAsc ? SortState.ShortDescriptionDesc : SortState.ShortDescriptionAsc;
            ViewData["SectionSort"] = sortOrder == SortState.SectionAsc ? SortState.SectionDesc : SortState.SectionAsc;

            books = sortOrder switch
            {
                SortState.BookNameDesc => books.OrderByDescending(b => b.BookName),
                SortState.AuthorNameAsc => books.OrderBy(b => b.AuthorName),
                SortState.AuthorNameDesc => books.OrderByDescending(b => b.AuthorName),
                SortState.RatingAsc => books.OrderBy(b => b.Rating),
                SortState.RatingDesc => books.OrderByDescending(b => b.Rating),
                SortState.ShortDescriptionAsc => books.OrderBy(b => b.ShortDescription),
                SortState.ShortDescriptionDesc => books.OrderByDescending(b => b.ShortDescription),
                SortState.SectionAsc => books.OrderBy(b => b.Section),
                SortState.SectionDesc => books.OrderByDescending(b => b.Section),
                _ => books.OrderBy(b => b.BookName),
            };

            return View(await books.AsNoTracking().ToListAsync());
        }

        // create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // update
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Book? book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book != null) return View(book);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            db.Books.Update(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // delete
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Book book = new Book { Id = id.Value };
                db.Entry(book).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}