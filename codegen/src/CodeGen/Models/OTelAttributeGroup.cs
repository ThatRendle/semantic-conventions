using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace CodeGen.Models;

public class OTelAttributeGroup : OTelObject
{
    [YamlMember( Alias = "display_name")]
    public string? DisplayName { get; set; }
    [YamlMember( Alias = "attributes")]
    public OTelAttribute[]? Attributes { get; set; }

    public static OTelAttributeGroup FromYaml(YamlMappingNode map)
    {
        var group = new OTelAttributeGroup();
        OTelObject.LoadYaml(group, map);
        LoadYaml(group, map);
        return group;
    }

    private static void LoadYaml(OTelAttributeGroup group, YamlMappingNode map)
    {
        group.DisplayName = map.GetStringOrDefault("display_name");

        if (map["attributes"] is YamlSequenceNode attributes)
        {
            var list = new List<OTelAttribute>();
            foreach (var a in attributes.OfType<YamlMappingNode>())
            {
                list.Add(OTelAttribute.FromYaml(a));
            }
            group.Attributes = list.ToArray();
        }
    }
}