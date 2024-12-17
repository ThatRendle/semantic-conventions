using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace CodeGen.Models;

public class OTelMetric : OTelObject
{
    [YamlMember( Alias = "metric_name")]
    public string? MetricName { get; set; }
    [YamlMember( Alias = "instrument")]
    public string? Instrument { get; set; }
    [YamlMember( Alias = "unit")]
    public string? Unit { get; set; }

    public static OTelMetric? FromYaml(YamlMappingNode map)
    {
        var metric = new OTelMetric();
        OTelObject.LoadYaml(metric, map);
        LoadYaml(metric, map);
        return metric;
    }

    private static void LoadYaml(OTelMetric metric, YamlMappingNode map)
    {
        metric.MetricName = map.GetStringOrDefault("metric_name");
        metric.Instrument = map.GetStringOrDefault("instrument");
        metric.Unit = map.GetStringOrDefault("unit");
    }
}