using CodeGen.Models;
using YamlDotNet.RepresentationModel;

namespace CodeGen;

public class Loader
{
    private List<OTelObject> _objects = new();
    public IReadOnlyList<OTelObject> Objects => _objects;

    public void Load(YamlDocument doc)
    {
        var root = (YamlMappingNode)doc.RootNode;

        if (root["groups"] is not YamlSequenceNode groups) return;

        foreach (var group in groups.OfType<YamlMappingNode>())
        {
            if (group.GetOTelObjectType() is not {Length: > 0} type) continue;

            switch (type)
            {
                case "metric":
                    if (OTelMetric.FromYaml(group) is { } metric) _objects.Add(metric);
                    break;
                case "attribute_group":
                    if (OTelAttributeGroup.FromYaml(group) is { } attributeGroup) _objects.Add(attributeGroup);
                    break;
            }
        }
    }
}