using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public class Book
{
    public int BookID { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Пожалуйста, укажите название")]
    public string Title { get; set; }
    [DisplayName("Автор")]
    [Required(ErrorMessage = "Пожалуйста, укажите автора")]
    public string Author { get; set; }
    [DisplayName("Дата публикации")]
    [Required(ErrorMessage = "Пожалуйста, укажите дату")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Range(typeof(DateTime), "1753-01-01", "9999-12-31", ErrorMessage = "Дата публикации должна быть между 1/1/1753 и 12/31/9999")]
    public DateTime? YearOfPublication { get; set; }
    [DisplayName("Оглавление")]
    public string? TableOfContents { get; set; }
}
