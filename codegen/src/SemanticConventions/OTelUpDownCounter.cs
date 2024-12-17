using System.Diagnostics.Metrics;
using System.Numerics;

namespace OTel;

public abstract class OTelUpDownCounterMetric : OTelMetric
{
    public UpDownCounter<T> Create<T>(Meter meter, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateUpDownCounter<T>(MetricName!, Unit, Brief, tags ?? []);
    }

    public ObservableUpDownCounter<T> CreateObservable<T>(Meter meter, Func<T> observer, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateObservableUpDownCounter<T>(MetricName!, observer, Unit, Brief, tags ?? []);
    }
}