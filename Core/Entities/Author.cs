namespace Core.Entities;

public class Author : BaseEntity
{
    public required string Name { get; set; }
    public required string Biography { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required string Nationality { get; set; }
    public required string Gender { get; set; }
    public string? Image { get; set; }
}
