using System.Diagnostics.Metrics;
using System.Numerics;

namespace OTel;

public abstract class OTelHistogramMetric : OTelMetric
{
    public Histogram<T> Create<T>(Meter meter, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateHistogram<T>(MetricName!, Unit, Brief, tags ?? []);
    }
    
    public Histogram<T> Create<T>(Meter meter, InstrumentAdvice<T> instrumentAdvice, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateHistogram(MetricName!, Unit, Brief, tags ?? [], instrumentAdvice);
    }
}