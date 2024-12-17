using YamlDotNet.Serialization;

namespace CodeGen.Models;

public class OTelGroups
{
    [YamlMember( Alias = "groups")]
    public List<OTelObject> Groups { get; set; }
}