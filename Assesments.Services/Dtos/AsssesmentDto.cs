namespace Assesments.Services;

public class AsssesmentDto
{

    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public string Tags { get; set; }
    public int PriorityId { get; set; }
    public string PriorityName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }






}
