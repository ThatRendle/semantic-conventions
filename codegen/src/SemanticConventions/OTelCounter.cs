using System.Diagnostics.Metrics;
using System.Numerics;

namespace OTel;

public abstract class OTelCounterMetric : OTelMetric
{
    public Counter<T> Create<T>(Meter meter, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateCounter<T>(MetricName!, Unit, Brief, tags ?? []);
    }
    
    public ObservableCounter<T> CreateObservable<T>(Meter meter, Func<T> observer, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateObservableCounter<T>(MetricName!, observer, Unit, Brief, tags ?? []);
    }
}