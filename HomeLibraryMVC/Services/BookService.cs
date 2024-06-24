using DataLayer;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.FromSqlRaw("EXEC SelectBooks").ToListAsync();
        }

        public Book GetBookById(int bookId)
        {
            var bookIdParam = new SqlParameter("@BookID", bookId);
            return  _context.Books
                .FromSqlRaw("EXEC GetBookById @BookID", bookIdParam).AsEnumerable()
                .FirstOrDefault();
        }

        public async Task AddBookAsync(Book book)
        {
            var titleParam = new SqlParameter("@Title", book.Title);
            var authorParam = new SqlParameter("@Author", book.Author);
            var yearOfPublicationParam = new SqlParameter("@YearOfPublication", book.YearOfPublication);
            var tableOfContentsParam = new SqlParameter("@TableOfContents", book.TableOfContents ?? (object)DBNull.Value);

            await _context.Database.ExecuteSqlRawAsync("EXEC InsertBook @Title, @Author, @YearOfPublication, @TableOfContents",
                titleParam, authorParam, yearOfPublicationParam, tableOfContentsParam);
        }

        public async Task UpdateBookAsync(Book book)
        {
            var bookIdParam = new SqlParameter("@BookID", book.BookID);
            var titleParam = new SqlParameter("@Title", book.Title);
            var authorParam = new SqlParameter("@Author", book.Author);
            var yearOfPublicationParam = new SqlParameter("@YearOfPublication", book.YearOfPublication);
            var tableOfContentsParam = new SqlParameter("@TableOfContents", book.TableOfContents ?? (object)DBNull.Value);

            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateBook @BookID, @Title, @Author, @YearOfPublication, @TableOfContents",
                bookIdParam, titleParam, authorParam, yearOfPublicationParam, tableOfContentsParam);
        }

        public async Task DeleteBookAsync(int id)
        {
            var bookIdParam = new SqlParameter("@BookID", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteBook @BookID", bookIdParam);
        }
    }
}
