using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace CodeGen.Models;

public class OTelAttribute : OTelObject
{
    public string? Value { get; set; }
    public string? Ref { get; set; }
    public string? RequirementLevel { get; set; }
    public string? RequirementCondition { get; set; }
    
    [YamlMember( Alias = "examples")]
    public object[]? Examples { get; set; }
    
    public OTelAttributeMember[]? Members { get; set; }

    public static OTelAttribute FromYaml(YamlMappingNode map)
    {
        var attribute = new OTelAttribute();
        OTelObject.LoadYaml(attribute, map);
        LoadYaml(attribute, map);
        return attribute;
    }

    private static void LoadYaml(OTelAttribute attribute, YamlMappingNode map)
    {
        var list = new List<OTelAttributeMember>();
        attribute.Ref = map.GetStringOrDefault("ref");
        if (map.TryGetNode("requirement_level", out var requirementLevel))
        {
            if (requirementLevel is YamlScalarNode scalar)
            {
                attribute.RequirementLevel = scalar.Value;
            }
            else if (requirementLevel is YamlMappingNode sub)
            {
                if (sub.TryGetNode("conditionally_required", out var conditionallyRequired))
                {
                    attribute.RequirementLevel = "required";
                    if (conditionallyRequired is YamlScalarNode conditionallyRequiredScalar)
                    {
                        attribute.RequirementCondition = conditionallyRequiredScalar.Value;
                    }
                }
            }
        }
        if (map["type"] is YamlMappingNode type && type["members"] is YamlSequenceNode members)
        {
            attribute.Type = "enum";
            foreach (var member in members.OfType<YamlMappingNode>())
            {
                list.Add(OTelAttributeMember.FromYaml(member));
            }
            attribute.Members = list.ToArray();
        }
    }
}