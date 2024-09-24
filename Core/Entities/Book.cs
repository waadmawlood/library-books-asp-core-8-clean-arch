namespace Core.Entities;

public class Book : BaseEntity
{
    public required string Title { get; set; }
    public required Author Author { get; set; }
    public required string Description { get; set; }
    public required string ISBN { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly PublicationDate { get; set; }
    public required string Language { get; set; }
    public required Category Category { get; set; }
    public string? Filename { get; set; }
    public string? Image { get; set; }
}
