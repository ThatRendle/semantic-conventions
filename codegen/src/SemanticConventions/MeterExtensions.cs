using System.Diagnostics.Metrics;
using System.Numerics;

namespace OTel;

public static class MeterExtensions
{
    public static Counter<T> CreateCounter<T>(this Meter meter, OTelCounterMetric metric, IEnumerable<KeyValuePair<string, object?>>? tags = null)
        where T : struct, INumber<T>
    {
        return meter.CreateCounter<T>(metric.MetricName!, metric.Unit, metric.Brief, tags ?? []);
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, OTelCounterMetric metric, Func<T> observe, IEnumerable<KeyValuePair<string, object?>>? tags = null)
        where T : struct, INumber<T>
    {
        return meter.CreateObservableCounter<T>(metric.MetricName!, observe, metric.Unit, metric.Brief, tags ?? []);
    }

    public static UpDownCounter<T> CreateUpDownCounter<T>(this Meter meter, OTelUpDownCounterMetric metric, IEnumerable<KeyValuePair<string, object?>>? tags = null)
        where T : struct, INumber<T>
    {
        return meter.CreateUpDownCounter<T>(metric.MetricName!, metric.Unit, metric.Brief, tags ?? []);
    }

    public static ObservableUpDownCounter<T> CreateObservableUpDownCounter<T>(this Meter meter, OTelUpDownCounterMetric metric, Func<T> observe, IEnumerable<KeyValuePair<string, object?>>? tags = null)
        where T : struct, INumber<T>
    {
        return meter.CreateObservableUpDownCounter<T>(metric.MetricName!, observe, metric.Unit, metric.Brief, tags ?? []);
    }

    public static Gauge<T> CreateGauge<T>(this Meter meter, OTelGaugeMetric metric, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateGauge<T>(metric.MetricName!, metric.Unit, metric.Brief, tags ?? []);
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, OTelGaugeMetric metric, Func<T> observe, IEnumerable<KeyValuePair<string, object?>>? tags = null) where T : struct, INumber<T>
    {
        return meter.CreateObservableGauge<T>(metric.MetricName!, observe, metric.Unit, metric.Brief, tags ?? []);
    }

    public static Histogram<T> CreateHistogram<T>(this Meter meter, OTelHistogramMetric metric,
        IEnumerable<KeyValuePair<string, object?>>? tags = null, InstrumentAdvice<T>? instrumentAdvice = null)
        where T : struct, INumber<T>
    {
        return meter.CreateHistogram<T>(metric.MetricName!, metric.Unit, metric.Brief, tags ?? [], instrumentAdvice);
    }
}