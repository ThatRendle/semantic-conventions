using YamlDotNet.RepresentationModel;

namespace CodeGen.Models;

public class OTelAttributeMember : OTelObject
{
    public string? Value { get; set; }

    public static OTelAttributeMember FromYaml(YamlMappingNode map)
    {
        var member = new OTelAttributeMember();
        OTelObject.LoadYaml(member, map);
        LoadYaml(member, map);
        return member;
    }

    private static void LoadYaml(OTelAttributeMember member, YamlMappingNode map)
    {
        member.Value = map.GetStringOrDefault("value");
    }
}