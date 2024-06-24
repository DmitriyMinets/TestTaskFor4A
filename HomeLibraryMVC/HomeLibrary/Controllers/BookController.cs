using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace HomeLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;
        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await bookService.GetAllBooksAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await bookService.UpdateBookAsync(book);

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book =  bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
