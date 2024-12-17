namespace OTel;

public abstract class OTelMetric
{
    public string? Id { get; init; }
    public string? MetricName { get; init; }
    public string? Brief { get; init; }
    public string? Note { get; init; }
    public string? Instrument { get; init; }
    public string? Unit { get; init; }
    public string? Stability { get; init; }

    public override string ToString() => MetricName ?? GetType().Name;
    public static implicit operator string(OTelMetric metric) => metric.ToString();
}