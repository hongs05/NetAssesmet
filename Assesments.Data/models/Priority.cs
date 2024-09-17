namespace Assesments.Data;

public class Priority
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Assesment> Assesments { get; set; }

}
