using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs.Books;

public class BookDto
{
  
    public string Title { get;  set; }

 
    public string Genre { get;  set; }

    public string PublishDate { get;  set; }

    public string Auther { get; set; }
}
