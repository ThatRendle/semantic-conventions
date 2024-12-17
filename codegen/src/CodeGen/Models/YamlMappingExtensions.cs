using System.ComponentModel.DataAnnotations;
using YamlDotNet.RepresentationModel;

namespace CodeGen.Models;

public static class YamlMappingExtensions
{
    public static string? GetStringOrDefault(this YamlMappingNode map, string key)
    {
        var keyNode = new YamlScalarNode(key);
        var pair = map.Children.FirstOrDefault(p => p.Key.Equals(keyNode));
        if (pair.Value is YamlScalarNode { Value: { Length: > 0} } scalar)
        {
            var value = scalar.Value.Replace("\n", "\\n");
            return value;
        }

        return null;
    }

    public static string? GetOTelObjectType(this YamlMappingNode map)
    {
        return map["type"] is YamlScalarNode scalar ? scalar.Value : null;
    }

    public static bool TryGetNode(this YamlMappingNode map, string key, out YamlNode? node)
    {
        var keyNode = new YamlScalarNode(key);
        node = map.Children.FirstOrDefault(p => p.Key.Equals(keyNode)).Value;
        return node != null;
    }
}