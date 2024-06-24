using DataLayer.Models;

namespace DataLayer
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }

            var books = new Book[]
            {
                new() {
                    Title = "Первая книга",
                    Author = "Первый автор",
                    YearOfPublication = new DateTime(2000, 1, 1),
                    TableOfContents = "<ol>\r\n  <li>Первая глава</li>\r\n  <li>Вторая глава глава</li>\r\n  <li>Третья глава глава</li>\r\n</ol>"
                },
                new() {
                    Title = "Вторая книга",
                    Author = "Второй автор",
                    YearOfPublication = new DateTime(2010, 1, 1),
                     TableOfContents = "<ol>\r\n  <li>Первая глава</li>\r\n  <li>Вторая глава глава</li>\r\n  <li>Третья глава глава</li>\r\n</ol>"
                }
            };

            foreach (var book in books)
            {
                context.Books.Add(book);
            }
            context.SaveChanges();
        }
    }
}
