using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs.Members;

public class AddMemberDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
}


