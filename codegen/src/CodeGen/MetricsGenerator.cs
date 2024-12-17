using System.CodeDom.Compiler;
using CodeGen.Models;

namespace CodeGen;

public class MetricsGenerator
{
    private readonly OTelMetric[] _metrics;
    private readonly string _outputPath;
    private readonly HashSet<string> _generated = new();

    public MetricsGenerator(IEnumerable<OTelObject> objects, string outputPath)
    {
        _outputPath = outputPath;
        _metrics = objects.OfType<OTelMetric>().ToArray();
    }

    public void Generate()
    {
        var groups = _metrics
            .Select(m => m.Id.Split('.').Skip(1).FirstOrDefault())
            .Where(id => id is { Length: > 0 })
            .Select(s => s!)
            .ToHashSet();

        foreach (var group in groups)
        {
            using var stringWriter = File.CreateText(Path.Combine(_outputPath, $"{group}.cs"));
            using var writer = new IndentedTextWriter(stringWriter);
            
            writer.WriteLine("namespace OTel");
            writer.OpenBrace();
            writer.WriteLine($"public partial class Metrics");
            writer.OpenBrace();
            GenerateMetricClass("metric", group, writer, 0);
            writer.CloseBrace();
            writer.CloseBrace();
        }
    }

    private void GenerateMetricClass(string prefix, string name, IndentedTextWriter writer, int depth)
    {
        var id = $"{prefix}.{name}";
        if (!_generated.Add(id)) return;
        
        var instance = _metrics
            .FirstOrDefault(m => m.Id == $"{prefix}.{name}");

        var baseClass = instance?.Instrument switch
            {
                "counter" => "OTelCounterMetric",
                "updowncounter" => "OTelUpDownCounterMetric",
                "gauge" => "OTelGaugeMetric",
                "histogram" => "OTelHistogramMetric",
                _ => "OTelMetric"
            };

        var pascalName = ToPascalCase(name);
        writer.WriteLine($"public partial class {pascalName}Metric : {baseClass}");
        writer.OpenBrace();

        var startsWith = $"{prefix}.{name}.";
        
        var subMetrics = _metrics
            .Where(m => m.Id.StartsWith(startsWith))
            .ToArray();

        if (subMetrics.Length > 0)
        {
            foreach (var subMetric in subMetrics)
            {
                GenerateMetricClass(id, subMetric.Id.Substring(startsWith.Length).Split('.')[0], writer, depth + 1);
            }
        }
        
        writer.CloseBrace();
        writer.WriteLine();
        writer.Write($"public ");
        if (depth == 0) writer.Write("static ");
        writer.WriteLine($"{ToPascalCase(name)}Metric {ToPascalCase(name)} {{ get; }} = new()");
        writer.OpenBrace();
        writer.WriteLine($"Id = \"{prefix}.{name}\",");
        if (instance is not null)
        {
            WriteObjectInitializer(writer, instance);
        }
        writer.CloseBrace(';');
    }

    private static void WriteObjectInitializer(IndentedTextWriter writer, OTelMetric instance)
    {
        if (instance.MetricName is { Length: > 0 })
        {
            writer.WriteLine($"MetricName = \"{instance.MetricName}\",");
        }
        if (instance.Brief is { Length: > 0 })
        {
            writer.WriteLine($"Brief = \"{instance.Brief}\",");
        }
        if (instance.Note is { Length: > 0 })
        {
            writer.WriteLine($"Note = \"{instance.Note}\",");
        }
        if (instance.Instrument is { Length: > 0 })
        {
            writer.WriteLine($"Instrument = \"{instance.Instrument}\",");
        }
        if (instance.Unit is { Length: > 0 })
        {
            writer.WriteLine($"Unit = \"{instance.Unit}\",");
        }
        if (instance.Stability is { Length: > 0 })
        {
            writer.WriteLine($"Stability = \"{instance.Stability}\",");
        }
    }

    private static string ToPascalCase(string str)
    {
        return str.Split('_', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(x => x.First().ToString().ToUpper() + x.Substring(1))
            .Aggregate((a, b) => a + b);
    }
}