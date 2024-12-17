using System.Diagnostics.Metrics;
using System.Numerics;

namespace OTel;

public abstract class OTelGaugeMetric : OTelMetric
{
    public Gauge<T> Create<T>(Meter meter, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateGauge<T>(MetricName!, Unit, Brief, tags ?? []);
    }

    public ObservableGauge<T> CreateObservable<T>(Meter meter, Func<T> observer, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateObservableGauge<T>(MetricName!, observer, Unit, Brief, tags ?? []);
    }
}