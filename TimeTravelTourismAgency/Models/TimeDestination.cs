namespace TimeTravelTourismAgency.Models;

public class TimeDestination
{
    public int Id { get; set; } //primary key
    public string Title { get; set; } = string.Empty;
    public string TargetYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int DangerLevel { get; set; } = 1;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
