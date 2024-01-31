using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs.Books;

public class EditBookDto
{

    [Required]
    [MaxLength(100)]
    public string Title { get;  set; }
    [Required]
    [MaxLength(25)]
    public string Genre { get; set; }
    [Required]
    [MaxLength(12)]
    public string PublishDate { get; set; }
    [Required]
    [MaxLength(75)]
    public string Auther { get; set; }
}
