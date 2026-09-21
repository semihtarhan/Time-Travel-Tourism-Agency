namespace TimeTravelTourismAgency.DTOs;

public class TimeDestinationDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TargetYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int DangerLevel { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateTimeDestinationDto
{
    public string Title { get; set; } = string.Empty;
    public string TargetYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int DangerLevel { get; set; } = 1;
}

public class UpdateTimeDestinationDto
{
    public string Title { get; set; } = string.Empty;
    public string TargetYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int DangerLevel { get; set; }
    public bool IsActive { get; set; }
}