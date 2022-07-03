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
        public async Task<IActionResult> Index()
        {
            return View(await db.Books.ToListAsync());
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