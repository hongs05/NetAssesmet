using System.ComponentModel.DataAnnotations;

namespace Assesments.Api;

public class CreateUserDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string Phone { get; set; }
}
