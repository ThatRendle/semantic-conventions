using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace CodeGen.Models;

public abstract class OTelObject
{
    [YamlMember(Alias = "id")]
    public string? Id { get; set; } = null!;
    [YamlMember( Alias = "type")]
    public string? Type { get; set; }
    [YamlMember( Alias = "brief")]
    public string? Brief { get; set; }
    [YamlMember( Alias = "note")]
    public string? Note { get; set; }
    [YamlMember( Alias = "stability")]
    public string? Stability { get; set; }

    public static void LoadYaml(OTelObject obj, YamlMappingNode map)
    {
        obj.Id = map.GetStringOrDefault("id");
        obj.Type = map.GetStringOrDefault("type");
        obj.Brief = map.GetStringOrDefault("brief");
        obj.Note = map.GetStringOrDefault("note");
        obj.Stability = map.GetStringOrDefault("stability");
    }
}
