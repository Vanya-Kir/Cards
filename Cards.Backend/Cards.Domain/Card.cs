namespace Cards.Domain;

public class Card
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }
}