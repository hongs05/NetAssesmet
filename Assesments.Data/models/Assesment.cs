namespace Assesments.Data;

public class Assesment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public bool Ended { get; set; }
    public bool Deleted { get; set; }
    public string Tags { get; set; }
    public int PriorityId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; }
    public Priority Priority { get; set; }

}
