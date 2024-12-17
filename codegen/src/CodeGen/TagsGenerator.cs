using System.CodeDom.Compiler;
using CodeGen.Models;

namespace CodeGen;

public class TagsGenerator
{
    private readonly OTelAttributeGroup[] _groups;
    private readonly string _outputPath;
    private readonly HashSet<string> _generated = new();

    public TagsGenerator(IEnumerable<OTelObject> objects, string outputPath)
    {
        _outputPath = outputPath;
        _groups = objects.OfType<OTelAttributeGroup>().ToArray();
    }

    public void Generate()
    {
        var registries = _groups
            .Where(g => g.Id.StartsWith("registry.") && !g.Id.Substring(9).Contains('.'))
            .Select(g => g.Id.Substring(9))
            .Distinct()
            .ToArray();

        foreach (var registry in registries)
        {
            using var stringWriter = File.CreateText(Path.Combine(_outputPath, $"{registry}.registry.cs"));
            using var writer = new IndentedTextWriter(stringWriter);
            
            writer.WriteLine("namespace OTel");
            writer.OpenBrace();
            writer.WriteLine("public static partial class Registry");
            writer.OpenBrace();
            writer.CloseBrace();
            writer.CloseBrace();
            writer.CloseBrace();
        }
    }

    private void WriteTag(string prefix, string name, IndentedTextWriter writer)
    {
        var group = _groups.FirstOrDefault(g => g.Id == $"{prefix}.{name}");
        var subs = _groups.Where(g => g.Id.StartsWith($"{prefix}.{name}.")).ToArray();
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