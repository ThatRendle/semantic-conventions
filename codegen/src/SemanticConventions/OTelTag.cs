namespace OTel;

public abstract class OTelTag
{
    public string Id { get; set; } = null!;
    public string? Type { get; set; }
}