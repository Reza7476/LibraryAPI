using System.ComponentModel.DataAnnotations;

namespace LibraryAPI;

public class AddBookDto
{


    [Required]
    [MaxLength(75)]
    public string Title { get; set; }

    [Required]
    [MaxLength(25)]
    public string  Genre { get; set; }
    [Required]
    [MaxLength(12)]

    public string  PublishDate { get; set; }

    [Required]
    [MaxLength(75)]
    public string  Auther { get; set; }
}
