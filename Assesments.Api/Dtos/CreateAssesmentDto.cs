using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Assesments.Api;

public class CreateAssesmentDto
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public string Tags { get; set; }
    public int PriorityId { get; set; }

}
