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
        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.BookNameAsc)
        {
            int pageSize = 3;

            IQueryable<Book> books = db.Books;

            // filtering
            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(b => b.BookName!.Contains(name));
            }

            // sorting
            switch (sortOrder)
            {
                case SortState.BookNameDesc:
                    books = books.OrderByDescending(b => b.BookName);
                    break;
                case SortState.AuthorNameAsc:
                    books = books.OrderBy(b => b.AuthorName);
                    break;
                case SortState.AuthorNameDesc:
                    books = books.OrderByDescending(b => b.AuthorName);
                    break;
                case SortState.RatingAsc:
                    books = books.OrderBy(b => b.Rating);
                    break;
                case SortState.RatingDesc:
                    books = books.OrderByDescending(b => b.Rating);
                    break;
                case SortState.ShortDescriptionAsc:
                    books = books.OrderBy(b => b.ShortDescription);
                    break;
                case SortState.ShortDescriptionDesc:
                    books = books.OrderByDescending(b => b.ShortDescription);
                    break;
                case SortState.SectionAsc:
                    books = books.OrderBy(b => b.Section);
                    break;
                case SortState.SectionDesc:
                    books = books.OrderByDescending(b => b.Section);
                    break;
                default:
                    books = books.OrderBy(b => b.BookName);
                    break;
            }

            // pagination
            var count = await books.CountAsync();
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // view model building
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(name),
                new SortViewModel(sortOrder)
                );

            //return View(await books.AsNoTracking().ToListAsync());
            return View(viewModel);
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